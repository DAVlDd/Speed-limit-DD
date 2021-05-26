
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public Rigidbody rb;
    public float playerSpeed = 500f;
    public GameObject cam;
    public float timer = 2f;
    public bool timerDestructOn = false;
    public float Maintimer = 180f;
    public bool MaintimerOn = false;
    public float gamespeed = 1;
    public double escCounter = 0;
    public bool paused = false;
    public bool timeAdded = false;
    public bool secondaryTimeAdded = false;
    public GameObject[] enemys; // allows multiple game objects to be accessed i think
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.Find("MainCamera");
        enemys = GameObject.FindGameObjectsWithTag("enemy"); // probably sets enemys to all objects with tag enemy
        MaintimerOn = true; //sets game timer on
    }

    void FixedUpdate() // Fixed update is better for physics objects
    {
        //player input for movement
        if (Input.GetKey("a"))
        {
            rb.AddForce(-playerSpeed * Time.deltaTime, 0, 0);
        };
        if (Input.GetKey("d"))
        {
            rb.AddForce(playerSpeed * Time.deltaTime, 0, 0);
        };

        if (Maintimer < 120 & Maintimer > 81) 
        {
            gamespeed = 1.3f;

            if (timeAdded == false)
            {
                Maintimer = Maintimer + Maintimer * 0.3f;
                timeAdded = true; // ensures time is only added once
            }
                // speeds up game and makes higher difficulty while accounting for speed boost
        };

        if (Maintimer < 78)
        {
            gamespeed = 1.6f;
            if (secondaryTimeAdded == false)
            {
                gamespeed = 1.6f;    // speeds up game and makes even higher difficulty
                Maintimer = 96; //ensures game will still last 3 minutes
                secondaryTimeAdded = true;
            };
        };
    }
    public void Update() //happens every frame
    {
        if (!paused)  // if not paused then game moves
        {
            Time.timeScale = gamespeed;
        };

        // misc timer for Delays etc.
        if (timerDestructOn == true)
        {
            timer = timer - Time.deltaTime;
            if (timer < 0)
            {
                Destroy(gameObject);
                timer = 0;
                timerDestructOn = false;
            };
        };
        // game timer, when it reaches zero, game end
        if (MaintimerOn == true)
        {
            Maintimer = Maintimer - Time.deltaTime;
            if (Maintimer == 0)
            {
                Debug.Log("game over");
                MaintimerOn = false;
            };
        };

        //pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escCounter = escCounter + 1;
            if (escCounter == 1)
            {
                paused = true;
                Time.timeScale = 0;
            };   
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escCounter == 2)
            {
                paused = false;
                escCounter = 0; // I used this method to allow the user to press esc twice instead of using separate keys to unpause
            };

        }

    }

    // collisions with player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "enemy")
        {
            cam.GetComponent<camFollow>().enabled = false;
            rb.AddForce(0, 2100f, 200f);
            timer = 2f; //sets delay for when collided with enemy
            timerDestructOn = true; // starts countdown
        }

        if(collision.collider.name == "grass")
            {
            cam.GetComponent<camFollow>().enabled = false;
            rb.AddForce(0, 200f, -1000f); //  player appears as if it has lost all momentum
        }
        if(collision.collider.name == "endDetector")
        {
            Destroy(gameObject);
            Debug.Log("game over"); //if player hits grass, they hit end detector which ends game
        }
    }
}
