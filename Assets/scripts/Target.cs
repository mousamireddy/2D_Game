using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public GameObject[] SpawnPoints; 
    public float health = 100f;
    public Material EggBreak, Egg;
    public GameObject BOOM;
    public GameObject SPAN;
    //public Time Timee;
    private void Start()
    {
    }
    public void Takedamage(float amount)
    {
        health -= amount;
       
        GetComponent<MeshRenderer>().material = EggBreak;
       
        if (health <= 0f)
        {
            
            BOOM.gameObject.SetActive(true);
            StartCoroutine(playpart());

        }
    }
    void Die()
    {
        gameObject.SetActive(false);
        health = 100;
        GetComponent<MeshRenderer>().material = Egg;
        int tempIndex = Random.Range(0, SpawnPoints.Length);
        gameObject.transform.position = SpawnPoints[tempIndex].transform.position;
        BOOM.gameObject.SetActive(false);
        SPAN.gameObject.SetActive(true);
        gameObject.SetActive(true);
        
        
       
    }

    IEnumerator playpart()
    {
        yield return new WaitForSeconds(0.2f);
        Die();
        SPAN.gameObject.SetActive(false);


    }
}