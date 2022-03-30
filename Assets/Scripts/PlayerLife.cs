using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

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
            GetHurt(collision);
        }
    }

    private void GetHurt(Collision2D collision)
    {
        anim.SetTrigger("player_hurt");
        //rb.AddForce(Vector2.left * (rb.velocity.x * 500), ForceMode2D.Force);
        float magnitude = 500;

        var force = transform.position - collision.transform.position;

        force.Normalize();
        rb.AddForce(force * magnitude);
    }
}
