using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    public AudioClip coinGet;
    public AudioClip accelPoint;
    public AudioClip warpPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveH, 0, moveV);
        rb.AddForce(movement * moveSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(coinGet, transform.position);
        }
        else if (other.CompareTag("Accel"))
        {
            rb.AddForce(new Vector3(0, 10, 30), ForceMode.VelocityChange);
            AudioSource.PlayClipAtPoint(accelPoint, transform.position);
        }
        else if (other.CompareTag("warp"));
        {
            transform.position = new Vector3(-3, 1, -3);
            AudioSource.PlayClipAtPoint(warpPoint, transform.position);
        } 
        
    }

}
