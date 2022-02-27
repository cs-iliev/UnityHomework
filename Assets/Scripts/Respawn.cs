using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject respawnTrigger;

    private void FixedUpdate()
    {
        // makes respawn trigger follow player
        respawnTrigger.transform.position = new Vector2(playerTransform.position.x, respawnTrigger.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RespawnTrigger"))
        {
            playerTransform.transform.position = respawnPoint.transform.position;
        }
    }
}

