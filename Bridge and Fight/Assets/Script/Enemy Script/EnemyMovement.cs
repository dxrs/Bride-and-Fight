using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]ParticleSystem enemyParticle;

    GameObject p1,p2;
    int numbOfPlayer;
    bool e_destroyed;
    Rigidbody2D rb;
    Vector2 movement;
    Vector2 dir;
    EnemyStat eStat;

    public AudioSource aSource;
    public AudioClip clipNya;
    // Start is called before the first frame update
    void Start()
    {
        eStat = GetComponent<EnemyStat>();

        rb = GetComponent<Rigidbody2D>();

        if (p1 != null && p2 != null)
        {
           
        }
        p1 = GameObject.FindGameObjectWithTag("Player 1");
        p2 = GameObject.FindGameObjectWithTag("Player 2");
        numbOfPlayer = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver.gameOver.isGameOver || GameFinish.gameFinish.isGameFinished) 
        {
            e_destroyed = true;

        }
        if (e_destroyed) 
        {
            Destroy(gameObject);
        }
        if(p1!=null && p2 != null) 
        {
            if (numbOfPlayer == 1)
            {
                dir = p1.transform.position - transform.position;
                //pterpilih = new Vector2(p1.transform.position.x,p1.transform.position.y);
            }
            if (numbOfPlayer == 2)
            {
                dir = p2.transform.position - transform.position;
                //pterpilih = p2.transform.position;
            }
        }
        else { return; }
       
       
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        dir.Normalize();
        movement = dir;
        
       
       
       
    }
    
    void FixedUpdate()
    {
        MoveChar(movement);
    }

    void MoveChar(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * eStat.speed * Time.deltaTime));
    }

    private void OnDestroy()
    {
        if (e_destroyed) 
        {
            Instantiate(enemyParticle, transform.position, Quaternion.identity);
        }
    }
}
