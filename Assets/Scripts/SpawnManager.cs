using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    public float startDelay = 2f;
    public float repeatRate = 2f;
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        
            InvokeRepeating("SpawnObject", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }


    public void SpawnObject()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
    }

}
