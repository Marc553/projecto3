using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 400f; //fuerza que ejecuta
    public float gravityModifier = 1;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.AddForce(Vector3.up * jumpForce);
        Physics.gravity *= gravityModifier; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce); 
        }
    }
}
