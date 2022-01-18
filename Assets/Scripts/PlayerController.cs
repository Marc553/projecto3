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
    public ParticleSystem particleExprosion;
    public ParticleSystem particlePolvo;
    public AudioClip jumpClip;
    public AudioClip crashClip;
    public AudioSource playerAudioSource;
    public AudioSource cameraAudioSource;

    private int lives = 3;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        // playerRigidbody.AddForce(Vector3.up * jumpForce);
        Physics.gravity *= gravityModifier;
        gameOver = false;
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
       
        //para cada vez que se reinicie todo, nos de 3 vidas, no las vidas de la partida pasada (osea 0 por qie se perdio)
        lives = 3;



    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
           //aplicacion de la fuerza para el salto 
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           
            //no esta tocando el suelo 
            isOnTheGround = false;
           
            //activa la aniamcion del salto 
            playerAnimator.SetTrigger("Jump_trig");
            
            //para las prticulas al saltar 
            particlePolvo.Stop();

            //sonido sato 
            playerAudioSource.PlayOneShot(jumpClip, 1);
        }


    }
     
    
     
   
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {
            
            //me permite saltar( cohca contra el objeto ETIQUETADO como "Ground")
            if (otherCollider.gameObject.CompareTag("Ground"))
            {
                isOnTheGround = true;
                particlePolvo.Play();

            }
            
            //Muero(Hará una acción cuando coqué contra el objeto ETIQUETADO como "Obatcle")
            if (otherCollider.gameObject.CompareTag("Obstacle"))
            {
                Destroy(otherCollider.gameObject);

                //llamo animacion de daño 
                playerAnimator.SetTrigger("Crash_trig");
                
                lives--;
                if (lives <= 0)
                {
                    GameOver();
                }


            }
            
            
        }

        


    } 

    private void GameOver()
    {
        gameOver = true;
        int randomDeath = Random.Range(1, 3);
        playerAnimator.SetBool("Death_b", true);
        playerAnimator.SetInteger("DeathType_int", randomDeath);

        //reproducir crash
        playerAudioSource.PlayOneShot(crashClip, 1);

        //Bajar el volumen del juego 
        cameraAudioSource.volume = 0.01f;


        particleExprosion.Play();
        particlePolvo.Stop();
    }
    
    


}
