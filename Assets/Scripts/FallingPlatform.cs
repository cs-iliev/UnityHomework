using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] float waitTime = 1f;
    private float destroyTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine("fallDown");
        }
    }

    private IEnumerator fallDown()
    {
        yield return new WaitForSeconds(waitTime);
        rb.isKinematic = false;
        Destroy(gameObject, destroyTime);
    }
}
