using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Roadmarks : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 resetPos = new Vector3 (0f, 0.16f, -220f);
   public static float playerSpeed = 2500f;
    // Start is called before the first frame update
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
            transform.position = resetPos;
        }
    }
}
