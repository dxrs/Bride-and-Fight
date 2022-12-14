
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBot : MonoBehaviour
{

    [SerializeField] ParticleSystem botParticle;

    [SerializeField] int nyawa;

    [SerializeField] float movementSpeed;

    GameObject target;

    float curSpeed = 5;


    Rigidbody2D rb;

    Vector2 movement;

    Vector2 dir;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        movementSpeed = curSpeed;
        target = GameObject.FindGameObjectWithTag("Target Bot");
    }


    void Update()
    {
        if(!GameOver.gameOver.isGameOver && !GameFinish.gameFinish.isGameFinished) 
        {
            if (target != null)
            {
                dir = target.transform.position - transform.position;
            }
            else
            {
                target = getRandomTarget();
            }


            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            dir.Normalize();
            movement = dir;
        }
        else 
        {
            Destroy(gameObject);
        }

        if (nyawa <= 0) { Destroy(gameObject); }

       
    }
    private void FixedUpdate()
    {
        botMovement(movement);
    }
    void botMovement(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));
    }

    GameObject getRandomTarget()
    {
       
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target Bot");

        
        int randomIndex = Random.Range(0, targets.Length);
        return targets[randomIndex];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Normal Enemy" || collision.gameObject.tag == "Medium Enemy")
        {
            if (Player1Health.player1Health.playerHealth < 50)
            {
                Player1Health.player1Health.playerHealth++;
            }
            else if (Player1Health.player1Health.playerHealth >= 50) { Player1Health.player1Health.playerHealth = 50; }
            if (Player2Health.player2Health.playerHealth < 50)
            {
                Player2Health.player2Health.playerHealth++;
            }
            else if (Player2Health.player2Health.playerHealth >= 50) { Player2Health.player2Health.playerHealth = 50; }
            
            Destroy(gameObject);
            //nyawa--;
            //print("kena");
        }

        if (collision.gameObject.tag == "Wall") 
        {
            target = getRandomTarget();
        }

        if (collision.gameObject.tag == "obstacle") 
        {
            movementSpeed = movementSpeed / 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            movementSpeed = curSpeed;
        }
    }



   


}