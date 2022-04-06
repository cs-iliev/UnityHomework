using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    private const int MAX_KEYS = 10;
    [SerializeField] private GameObject[] keyBar = new GameObject[MAX_KEYS];

    private int collectedKeys = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);

            keyBar[collectedKeys++].GetComponent<Animator>().SetTrigger("keyCollected");
            Debug.Log("Keys: " + collectedKeys);
        }
    }
}
