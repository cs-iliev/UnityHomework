using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject respawnTrigger;
    [SerializeField] private GameObject player;

    private void FixedUpdate()
    {
        // makes respawn trigger follow player
        respawnTrigger.transform.position = new Vector2(player.transform.position.x, respawnTrigger.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RespawnTrigger"))
        {
            player.GetComponent<PlayerLife>().TakeDamage();
            player.GetComponent<PlayerLife>().Die();
        }
    }
}

