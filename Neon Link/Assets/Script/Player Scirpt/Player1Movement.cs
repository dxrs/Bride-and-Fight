using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player1Movement : MonoBehaviour 
{
    

    [SerializeField] bool isBreaking;
    [SerializeField] bool isHitObstacle;

    float movePower;

    int maxSpeed;

    Rigidbody2D rb;

    CircleCollider2D cc;

    private void Start()
    {
        movePower = 15f;
        maxSpeed = 10;

        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        oldInputBreaking(); //memanggil fungsi pengereman
    }

    private void FixedUpdate()
    {
        if (!GameFinish.gameFinish.isGameFinished && GameStarting.gameStarting.isGameStarted)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
            oldInputMovementControl(); //memanggil fungsi movement
        }
    }

    #region fungsi pengereman

    private void oldInputBreaking() 
    {
        if(ShadowAbility.shadowAbility.isShadowActivated ||
            UIPauseGame.uIPauseGame.isSceneEnded) 
        {
            cc.enabled = false;
        }
        if(!ShadowAbility.shadowAbility.isShadowActivated &&
            !UIPauseGame.uIPauseGame.isSceneEnded) 
        {
            cc.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.D)
          || Input.GetKeyUp(KeyCode.A)
          || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            isBreaking = true;
        }
    }

    #endregion

    #region fungsi movement controller

    private void oldInputMovementControl() 
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

    #endregion

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

