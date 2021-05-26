using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stansScript : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 resetPos = new Vector3(20, -1, -150);
    public static float playerSpeed = 2500f;
    public double rol = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, -playerSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider otherInfo)
    {
        if (otherInfo.name == "endDetector")
        {
            // alternates between right and left of road
            if (rol == 1)
            {
                resetPos = new Vector3(40, -1, Random.Range(100, 0));
                rol = 2;
                transform.Rotate(new Vector3(0f, 90f, 0f));
            }
            else
            {
                resetPos = new Vector3(-40, -1, Random.Range(100, 0));
                rol = 1;
                transform.Rotate(new Vector3(0f, -90f, 0f));
            };
            // sets position of billboard 
            transform.position = resetPos;
        }
      }
    }
   