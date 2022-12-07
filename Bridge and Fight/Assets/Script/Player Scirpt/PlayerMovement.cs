using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerMovement;

    public float movePower;
   
    [SerializeField] int numbOfPlayer;
    [SerializeField] float movementSpeedP1;
    [SerializeField] float movementSpeedP2;

    float speedInUnitPerSecond;
    float curSpeed = 3;
    float slowSpeed = 1;
    int dir;

    Rigidbody2D rb;
    CircleCollider2D cc;

    private void Awake()
    {
        if (playerMovement == null) { playerMovement = this; }
    }
    private void Start()
    {

        cc = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        movementSpeedP1 = curSpeed;
        movementSpeedP2 = curSpeed;
        
    }
    private void Update()
    {
        if (GameFinish.gameFinish.isGameFinished) 
        {
            rb.drag =10;
        }
        
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.RightArrow))
        {
     
        
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
    private void FixedUpdate()
    {
        if (!GameFinish.gameFinish.isGameFinished && GameStarting.gameStarting.isGameStarted)
        {

            physicsControl();
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

    void physicsControl()
    {
        if (numbOfPlayer == 1)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(transform.right * movePower);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-transform.right * movePower);
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.up * movePower);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-transform.up * movePower);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(transform.right * movePower);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(-transform.right * movePower);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(transform.up * movePower);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(-transform.up * movePower);
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
                //movementSpeedP1 = slowSpeed;
                rb.drag = 5;
            }
            if (numbOfPlayer == 2) 
            {
                //print("kena p2");
                //movementSpeedP2 = slowSpeed;
                rb.drag = 5;
            }
            
        }

        
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "obstacle") 
        {
            
            if (numbOfPlayer == 1) 
            {
                //movementSpeedP1 = curSpeed;
                rb.drag = 0;
            }
            if (numbOfPlayer == 2) 
            {
                //movementSpeedP2 = curSpeed;
                rb.drag = 0;
            }
            
        }
    }
    


   
}
