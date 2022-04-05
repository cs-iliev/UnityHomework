using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private GameObject deathParticle;
    [SerializeField] private GameObject respawnParticle;

    [SerializeField] private Transform respawnPoint;
    private const int MAX_HEALTH = 3;

    private int health = 3;
    [SerializeField] private GameObject[] healthBar = new GameObject[MAX_HEALTH];

    private float respawnDuration = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetHurt();
            TakeDamage();
            KnockBack(collision);

        }
    }

    private void KnockBack(Collision2D collision)
    {
        float magnitude = 1000;
        var force = transform.position - collision.transform.position;

        force.Normalize();
        rb.AddForce(force * magnitude);
    }

    private void GetHurt()
    {
        anim.SetTrigger("player_hurt");
    }

    private IEnumerator respawnPlayer()
    {
        float becomeActiveAfter = 1;
        yield return new WaitForSeconds(respawnDuration);
        transform.position = respawnPoint.transform.position;
        Instantiate(respawnParticle, rb.transform.position, rb.transform.rotation);
        yield return new WaitForSeconds(becomeActiveAfter);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private IEnumerator restartGame()
    {
        yield return new WaitForSeconds(respawnDuration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("player_death");
        Instantiate(deathParticle, transform.position, transform.rotation);
        StartCoroutine("respawnPlayer");
    }

    public void TakeDamage()
    {
        healthBar[--health].GetComponent<Animator>().SetTrigger("damaged");

        if (health == 0)
        {
            Die();
            StartCoroutine("restartGame");
        }

        Debug.Log("Health: " + health);
    }
}
