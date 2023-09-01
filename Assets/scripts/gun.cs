using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
public class gun : MonoBehaviour
{
    public float damage = 50f;
    //public float range = 100f;
    public Camera fpsCam;
    public GameObject fire1;
    public int Kills;
    public Text KillsText;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            sounds.PlaySound("fire");
            Shoot();
            fire1.gameObject.SetActive(true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            fire1.gameObject.SetActive(false);
        }
    }
    void Shoot()
    {
        // particle.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 6000))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.Takedamage(damage);
                if(target.health == 0)
                {
                    Kills++;
                    KillsText.text = "Kills : " + Kills;
                }
            }
        }
    }
}