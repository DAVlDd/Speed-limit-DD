using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LtreeScript : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 resetPos = new Vector3(-15, -1, -200);
    public static float playerSpeed = 2500f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, -playerSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider otherInfo)
    {
        if (otherInfo.name == "endDetector")
        {
            // randomizes rotation and position when triggered by endDetector
            resetPos = new Vector3(Random.Range(-25, -10), -1, -200);
            transform.Rotate(new Vector3(0f, Random.Range(180, -180), 0f));
            transform.position = resetPos;
        }
    }
}
