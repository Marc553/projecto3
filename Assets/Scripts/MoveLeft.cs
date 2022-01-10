using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 15f;

    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
          transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
         
    }
}
