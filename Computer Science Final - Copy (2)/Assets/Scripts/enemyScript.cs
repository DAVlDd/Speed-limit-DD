using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 resetPos;
    public float enemySpeed = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, -enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "endDetector")
        {
            resetPos = new Vector3(Random.Range(-7, 7), 0.16f, Random.Range(-200, -100));
            transform.position = resetPos;
        }

        if (collision.collider.tag == "enemy")
        {
            resetPos = new Vector3(Random.Range(-7, 7), 0.16f, Random.Range(-200, -100));
            transform.position = resetPos;
        }
    }
}