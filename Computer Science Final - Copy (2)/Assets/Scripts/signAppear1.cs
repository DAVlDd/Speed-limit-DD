using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signAppear : MonoBehaviour
{
    public bool isAppearFirst = false;
    public bool isAppearSecond = false;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Car");
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
 void Update()
    {
        if (player == null)
        {
            gameObject.GetComponent<signAppear>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false; // if player is destroyed script stops
        }
    }
    void FixedUpdate()
    {
        if (isAppearFirst == false)
        {
            if (player.GetComponent<playerScript>().Maintimer < 121)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else { gameObject.GetComponent<MeshRenderer>().enabled = false; }
            if (player.GetComponent<playerScript>().timeAdded == true)
            {
                isAppearFirst = true;
            } // stops this portion from running after difficulty is put up for the first time
        }; // hopefully makes sign appear when one minute passes

        if (isAppearSecond == false)
        {
            if (isAppearFirst == true)
            {
                if (player.GetComponent<playerScript>().Maintimer < 80)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
                else { gameObject.GetComponent<MeshRenderer>().enabled = false; }
                if (player.GetComponent<playerScript>().secondaryTimeAdded == true)
                {
                    isAppearSecond = true;
                }
            }
        } // makes sign appear when game difficulty is at level 2




    }
}
