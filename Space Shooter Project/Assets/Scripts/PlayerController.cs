using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    public Rigidbody body;
    public float speed = 5f;
    public float tilt;
    public Boundary bound;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.5f;
    private float fireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > fireTime)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            fireTime = Time.time + 1 / fireRate;
            GetComponent<AudioSource>().Play();
        }
    }
    void FixedUpdate()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        body.velocity = new Vector3(xMove, 0, yMove) * speed;
        body.position = new Vector3(Mathf.Clamp(body.position.x, bound.xMin, bound.xMax), 0, Mathf.Clamp(body.position.z, bound.zMin, bound.zMax));

        body.rotation = Quaternion.Euler(0, 0, body.velocity.x * -tilt);
    }
}
