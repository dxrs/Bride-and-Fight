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

    [SerializeField]
    int maxSpeed;


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
        //rb.drag = 10F;

    }
    private void Update()
    {
        print(rb.velocity);
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
                if (!isHitObstacle)
                {
                    isBreaking = true;

                }
                else
                {
                    //isBreaking = false;
                }


            }
            if (isHitObstacle) 
            {
                if (isBreaking) { isBreaking = false; }
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
                else 
                {
                    //isBreaking = false;
                }
              


            }
            if (isHitObstacle)
            {
                if (isBreaking) { isBreaking = false; }
            }

        }
    }
    private void FixedUpdate()
    {
        if (!GameFinish.gameFinish.isGameFinished && GameStarting.gameStarting.isGameStarted)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
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
            }else if(!isBreaking && isHitObstacle) 
            {
                rb.drag = 4;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(transform.right * movePower);
                isBreaking = false;               
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-transform.right * movePower);
                isBreaking = false;
              
            }
            if (Input.GetKey(KeyCode.W))
            {
                isBreaking = false;
                
                rb.AddForce(transform.up * movePower);
               
            }
            if (Input.GetKey(KeyCode.S))
            {
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
            else if (!isBreaking && isHitObstacle)
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
