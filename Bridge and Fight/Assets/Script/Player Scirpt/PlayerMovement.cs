using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerMovement;

    public float movePower;
   
    [SerializeField] int numbOfPlayer;
    

    

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
        if (Input.GetButton("Abutton")) 
        {
            //print("bisa");
        }
        
       
    }
    private void FixedUpdate()
    {
        if (!GameFinish.gameFinish.isGameFinished && GameStarting.gameStarting.isGameStarted)
        {

            physicsControl();
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
            if (PlayerNumber.playerNumber.isSoloMode)
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
            else 
            {
                Vector2 inputDir = Vector2.zero;
                inputDir.x = Input.GetAxis("AnalogLeftHorizontal");
                inputDir.y = -Input.GetAxis("AnalogLeftVertical");
                rb.AddForce(inputDir * movePower);
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
                rb.drag = 3.5f;
            }
            if (numbOfPlayer == 2) 
            {
                //print("kena p2");
                //movementSpeedP2 = slowSpeed;
                rb.drag = 3.5f;
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
