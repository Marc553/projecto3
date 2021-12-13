using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 400f; //fuerza que ejecuta
    public float gravityModifier = 1;
    private bool isOnTheGround = true;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.AddForce(Vector3.up * jumpForce);
        Physics.gravity *= gravityModifier; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
            isOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        //me permite saltar( cohca contra el objeto ETIQUETADO como "Ground")
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }

        //Muero(Hará una acción cuando coqué contra el objeto ETIQUETADO como "Obatcle")
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            //Morir
        }


    }

    


}
