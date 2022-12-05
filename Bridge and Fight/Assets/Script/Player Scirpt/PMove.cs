using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMove : MonoBehaviour
{
    public int PlayerNumber;
    public float movePower;
    float speedInUnitPerSecond;

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
        print(speedInUnitPerSecond);
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
                //if(speedInUnitPerSecond <= 10)
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
    }
}
