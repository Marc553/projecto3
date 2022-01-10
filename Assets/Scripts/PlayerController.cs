using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 400f; //fuerza que ejecuta
    public float gravityModifier = 1;
    private bool isOnTheGround = true;
    public bool gameOver;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
       // playerRigidbody.AddForce(Vector3.up * jumpForce);
        Physics.gravity *= gravityModifier;
        gameOver = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        //Muero(Hará una acción cuando coqué contra el objeto ETIQUETADO como "Obatcle")
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            isOnTheGround = false;

        }
        //me permite saltar( cohca contra el objeto ETIQUETADO como "Ground")
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
            
        }

        


    }

    


}
