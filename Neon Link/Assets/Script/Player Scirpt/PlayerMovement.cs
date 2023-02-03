using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerMovement;

    public float movePower;
    public float linearDragValue;
   
    [SerializeField] int numbOfPlayer;


    float minLinearDrag = 0;
    float maxLinearDrag = 2f;

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
        rb.drag = 10F;

    }
    private void Update()
    {
        
       
        
        
        if (ShadowAbility.shadowAbility.isShadowActivated || UIPauseGame.uIPauseGame.isSceneEnded) 
        {
            cc.enabled = false;
        }
        if(!ShadowAbility.shadowAbility.isShadowActivated && !UIPauseGame.uIPauseGame.isSceneEnded) 
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
        if (UIPauseGame.uIPauseGame.isSceneEnded)
        {
           
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)
            || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)
            || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow)) 
        {
            //rb.drag = Mathf.Lerp(rb.drag, maxLinearDrag, 3 * Time.deltaTime);
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
            Vector2 inputDir = Vector2.zero;
            inputDir.x = Input.GetAxis("AnalogLeftHorizontal");
            inputDir.y = -Input.GetAxis("AnalogLeftVertical");
            rb.AddForce(inputDir * movePower);
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
            Vector2 inputDir = Vector2.zero;
            inputDir.x = Input.GetAxis("AnalogRightHorizontal");
            inputDir.y = -Input.GetAxis("AnalogRightVertical");
            rb.AddForce(inputDir * movePower);





        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "obstacle") 
        {
            
            if (numbOfPlayer == 1) 
            {
                
                rb.drag = 3.5f;
            }
            if (numbOfPlayer == 2) 
            {
                
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
               
                rb.drag = 10;
            }
            if (numbOfPlayer == 2) 
            {
               
                rb.drag = 10;
            }
            
        }
    }

   
    


   
}
