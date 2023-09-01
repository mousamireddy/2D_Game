using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Navigationmeshscript : MonoBehaviour
{
    public Image BreakImage;
    NavMeshAgent Agent;
    public GameObject Player;
    public GameObject fire2;
    //int count = 10;
    float Timer;
    bool isShooting;
    Playermovements PlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        PlayerScript = Player.GetComponent<Playermovements>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (PlayerScript.PlayerHealth == 0)
        //{
        //    SceneManager.LoadScene("game over");
        //}

        Agent.destination = Player.transform.position;
        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5000))
        {
            Timer += Time.deltaTime;
            if (System.Convert.ToInt32(Timer) % 2 == 0)
            {
                if (isShooting)
                {
                    isShooting = false;
                    if (hit.transform.CompareTag("Player"))
                    {
                        fire2.gameObject.SetActive(true);
                        PlayerScript.PlayerHealth -= 5f;
                        BreakImage.gameObject.SetActive(true);
                        Debug.Log(transform.gameObject.name + " is shooting you");
                    }
                    else
                    {
                        BreakImage.gameObject.SetActive(false);
                    }
                }
                if (Timer > 2)
                {
                    Timer = 0;
                    isShooting = true;
                }
            }
            else
            {
                fire2.gameObject.SetActive(false);
            }
            Vector3 relativePos = Player.transform.position - transform.position;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;
        }

    }
}
