using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunLookRotation : MonoBehaviour
{
    public Image BreakImage;
    private void Update()
    {
        RaycastHit hit;
       // Does the ray intersect any objects excluding the player layer
       if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,100))
       {
           if(hit.transform.name == "Player")
           {
               BreakImage.gameObject.SetActive(true);
               Debug.Log("shooting");
           }
           else
           {
               BreakImage.gameObject.SetActive(false);
               Debug.Log("not shooting");

           }
       }
    }
}
