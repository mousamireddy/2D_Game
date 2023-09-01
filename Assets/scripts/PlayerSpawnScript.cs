using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnScript : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public GameObject player;
    Vector3 respawnLocation;

    // Start is called before the first frame update
    private void Awake()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
    void Start()
    {
       player = (GameObject)Resources.Load("PLayer",typeof(GameObject)); 
       respawnLocation = player.transform.position;
       SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void SpawnPlayer()
    {
        int Spawn = Random.Range(0,SpawnPoints.Length);
        GameObject.Instantiate(player, SpawnPoints[Spawn].transform.position,Quaternion.identity);
    }
}
