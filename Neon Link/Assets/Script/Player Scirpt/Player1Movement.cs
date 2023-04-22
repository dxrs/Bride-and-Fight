using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public static Player1Movement player1Movement;

    [SerializeField] float movePower;

    [SerializeField] int maxSpeed;

    [SerializeField] bool isBreaking;
    [SerializeField] bool isHitObstacle;

    Rigidbody2D rb;
    CircleCollider2D cc;

    private void Awake()
    {
        if (player1Movement == null) { player1Movement = this; }
    }

    private void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (UIPauseGame.uIPauseGame.isSceneEnded) 
        {

        }
        else 
        {
            
        }

        if (Input.GetKeyUp(KeyCode.D)
          || Input.GetKeyUp(KeyCode.A)
          || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            isBreaking = true;
        }
    }

    private void FixedUpdate()
    {
        if(!GameFinish.gameFinish.isGameFinished && GameStarting.gameStarting.isGameStarted) 
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
            playerBreaking();
            controlSystemP1();
        }
    }

    private void controlSystemP1() 
    {
        if (ControlSystem.controlSystem.isSinglePlayer) 
        {
            // maen sendiri

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
            
            if (Input.GetAxis("AnalogLeftHorizontal") != 0 || Input.GetAxis("AnalogLeftVertical") != 0) 
            {
                Vector2 inputDir = Vector2.zero;
                inputDir.x = Input.GetAxis("AnalogLeftHorizontal");
                inputDir.y = -Input.GetAxis("AnalogLeftVertical");
                rb.AddForce(inputDir * movePower);
                print("konek"); 
            }
            else 
            {
                print("kgrgrgr");
                // kalo gamepad 1 tidak konek 
            }

          
        }
        else 
        {
            // maen berdua

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
        }
    }

    void playerBreaking() 
    {
        if (isBreaking && !isHitObstacle)
        {
            rb.drag = math.lerp(rb.drag, 3, 1 * Time.deltaTime);
        }
        else if (!isBreaking && !isHitObstacle)
        {
            rb.drag = 0;
        }
        else if (isHitObstacle)
        {
            rb.drag = 4;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle") 
        {
            isHitObstacle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            isHitObstacle = false;
        }
    }


}
