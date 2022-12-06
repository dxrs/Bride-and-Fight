using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerMovement;


    public int numbOfPlayer;

    public ParticleSystem playerParticle;

    public float slowMove = 1;
    public float curSpeed = 3;

    [SerializeField] float movementSpeedP1;
    [SerializeField] float movementSpeedP2;

    int dir;
   
    CircleCollider2D cc;

    private void Awake()
    {
        if (playerMovement == null) { playerMovement = this; }
    }
    private void Start()
    {

        cc = GetComponent<CircleCollider2D>();
        movementSpeedP1 = curSpeed;
        movementSpeedP1 = curSpeed;
        
    }
    private void Update()
    {
        if (!GameFinish.gameFinish.isGameFinished && GameStarting.gameStarting.isGameStarted) 
        {
            inputPlayer();
        }
        
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.RightArrow))
        {
            //GameStarting.gameStarting.isGameStarted = true;
        
        }
        if (ShadowAbility.shadowAbility.isShadowActivated) 
        {
            cc.enabled = false;
        }
        else 
        {
            cc.enabled = true;
        }
       
    }
    private void inputPlayer() 
    {
        playerControl();
        if (dir == 1) 
        {
            if (numbOfPlayer == 1) 
            {
                transform.Translate(movementSpeedP1 * Time.deltaTime, 0, 0);
            }
            else 
            {
                transform.Translate(movementSpeedP2 * Time.deltaTime, 0, 0);
            }
            
        }else if(dir == 2) 
        {
            if (numbOfPlayer == 1) 
            {
                transform.Translate(-movementSpeedP1 * Time.deltaTime, 0, 0);
            }
            else 
            {
                transform.Translate(-movementSpeedP2 * Time.deltaTime, 0, 0);
            }
            
        }
        else if (dir == 3) 
        {
            if (numbOfPlayer == 1)
            {
                transform.Translate(0, movementSpeedP1 * Time.deltaTime, 0);
            }
            else
            {
                transform.Translate(0, movementSpeedP2 * Time.deltaTime, 0);
            }
            
        }
        else if(dir == 4) 
        {
            if (numbOfPlayer == 1)
            {
                transform.Translate(0, -movementSpeedP1 * Time.deltaTime, 0);
            }
            else
            {
                transform.Translate(0, -movementSpeedP2 * Time.deltaTime, 0);
            }
            
        }
    }
    void playerControl() 
    {
        if (numbOfPlayer == 1)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                audioManager.amanager.moveSound();
                dir = 1;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                audioManager.amanager.moveSound();
                dir = 2;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                audioManager.amanager.moveSound();
                dir = 3;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                audioManager.amanager.moveSound();
                dir = 4;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                audioManager.amanager.moveSound();
                dir = 1;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                audioManager.amanager.moveSound();
                dir = 2;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                audioManager.amanager.moveSound();
                dir = 3;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                audioManager.amanager.moveSound();
                dir = 4;
            }
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "obstacle") 
        {
            
            if (numbOfPlayer == 1) 
            {
               // print("kena p1");
                movementSpeedP1 = slowMove;
            }
            if (numbOfPlayer == 2) 
            {
                //print("kena p2");
                movementSpeedP2 = slowMove;
            }
            
        }

        if(collision.gameObject.tag == "Normal Enemy" || collision.gameObject.tag=="tembok")
        {
            //if()
            PlayerDestroy.playerDestroy.isGameOver = true;
            Instantiate(playerParticle, transform.position, Quaternion.identity);
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "obstacle") 
        {
            
            if (numbOfPlayer == 1) 
            {
                movementSpeedP1 = curSpeed;
            }
            if (numbOfPlayer == 2) 
            {
                movementSpeedP2 = curSpeed;
            }
            
        }
    }


   
}
