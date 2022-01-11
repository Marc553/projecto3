using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 400f; //fuerza que ejecuta
    public float gravityModifier = 1;
    private bool isOnTheGround = true;
    public bool gameOver;
    private Animator playerAnimator;
   
     

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
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
            playerAnimator.SetTrigger("Jump_trig");
        }


    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        //Muero(Hará una acción cuando coqué contra el objeto ETIQUETADO como "Obatcle")
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            int randomDeath = Random.Range(1, 3);
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", randomDeath);


        }
        //me permite saltar( cohca contra el objeto ETIQUETADO como "Ground")
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
            
        }

        


    }

    


}
