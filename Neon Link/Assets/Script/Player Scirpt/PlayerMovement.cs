using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerMovement;

    public float movePower;

   
    [SerializeField] int numbOfPlayer;
    [SerializeField] bool isBreaking;
    [SerializeField] bool isHitObstacle;


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
        
       
        
        
        if (ShadowAbility.shadowAbility.isShadowActivated || UIPauseGame.uIPauseGame.isSceneEnded) 
        {
            cc.enabled = false;
        }
        if(!ShadowAbility.shadowAbility.isShadowActivated && !UIPauseGame.uIPauseGame.isSceneEnded) 
        {
            cc.enabled = true;
        }
        if (numbOfPlayer == 1)
        {
            if (Input.GetKeyUp(KeyCode.D)
           || Input.GetKeyUp(KeyCode.A)
           || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            {
                isBreaking = true;
               

            }
           
          
        }
        
        if (numbOfPlayer == 2)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow)
                || Input.GetKeyUp(KeyCode.DownArrow)
                || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
               
                if (!isHitObstacle)
                {

                    isBreaking = true;
                }
               
              


            }
          

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
       
        
       
    }
    
   
    

    void physicsControl()
    {
        if (numbOfPlayer == 1)
        {
            if (isBreaking && !isHitObstacle) 
            {
                rb.drag = math.lerp(rb.drag,3, 1*Time.deltaTime);
            }
            else if (!isBreaking && !isHitObstacle)
            {
                rb.drag = 0;
            }else if( isHitObstacle) 
            {
                rb.drag = 4;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(transform.right * movePower);
                //rb.drag = 0;
                isBreaking = false;
                if (!isHitObstacle) {  }
                
             
                //linearDragValue = Mathf.Lerp(minLinearDrag, maxLinearDrag, 3 * Time.deltaTime);
                
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-transform.right * movePower);
                isBreaking = false;
                if (!isHitObstacle) {  }
            }
            if (Input.GetKey(KeyCode.W))
            {
               
                if (!isHitObstacle) {  }
                isBreaking = false;
                rb.AddForce(transform.up * movePower);
               
            }
            if (Input.GetKey(KeyCode.S))
            {
               
                if (!isHitObstacle) {  }
                isBreaking = false;
                rb.AddForce(-transform.up * movePower);
               
            }
            Vector2 inputDir = Vector2.zero;
            inputDir.x = Input.GetAxis("AnalogLeftHorizontal");
            inputDir.y = -Input.GetAxis("AnalogLeftVertical");
            rb.AddForce(inputDir * movePower);
        }
        else
        {
            if (isBreaking && !isHitObstacle)
            {
                rb.drag = math.lerp(rb.drag, 3, 1 * Time.deltaTime);
            }
            else if (!isBreaking && !isHitObstacle)
            {
                rb.drag = 0;
            }
            else if ( isHitObstacle)
            {
                rb.drag = 4;
            }
            if (PlayerNumber.playerNumber.isSoloMode)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    rb.AddForce(transform.right * movePower);
                    isBreaking = false;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.AddForce(-transform.right * movePower);
                    isBreaking = false;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rb.AddForce(transform.up * movePower);
                    isBreaking = false;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    rb.AddForce(-transform.up * movePower);
                    isBreaking = false;
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
                isHitObstacle = true;
                //isBreaking = true;
            }
           
           
            if (numbOfPlayer == 2) 
            {
                isHitObstacle = true;
                //rb.drag = 2;
            }
            
        }

        
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "obstacle") 
        {
            if (numbOfPlayer == 1)
            {
                isHitObstacle = false;
                //isBreaking = false;
            }
           
           
            if (numbOfPlayer == 2) 
            {
                isHitObstacle = false;
                // rb.drag = 0;
            }
            
        }
    }

   
    


   
}
