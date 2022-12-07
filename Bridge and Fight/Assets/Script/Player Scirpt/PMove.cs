using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMove : MonoBehaviour
{
    public int PlayerNumber;
    public float movePower;
    float speedInUnitPerSecond;

    public float slowAmount;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedInUnitPerSecond = rb.velocity.magnitude;
        if(PlayerNumber == 1)
        {
            //print(speedInUnitPerSecond);
        }
    }

    void FixedUpdate()
    {
        movementInput();
    }

    void movementInput()
    {
        if(PlayerNumber ==1)
        {
            if(Input.GetKey(KeyCode.D))
            {
                rb.AddForce(transform.right * movePower);
            }
            if(Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-transform.right * movePower);
            }
            if(Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.up * movePower);
            }
            if(Input.GetKey(KeyCode.S))
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
            rb.drag = slowAmount;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "obstacle") 
        {
            rb.drag = 0;
        }
    }
}
