using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion, playerExplosion;
    public int score;
    private GameController controller;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Boundary"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            controller.AddScore(score);
            if (collider.CompareTag("Player"))
            {
                controller.GameOver();
                controller.AddScore(-score);
                Instantiate(playerExplosion, collider.transform.position, collider.transform.rotation);
            }
        }
    }
}