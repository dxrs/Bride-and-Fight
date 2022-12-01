using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfRay : MonoBehaviour
{

    public static LineOfRay lineOfRay;

    public ParticleSystem laserParticle;

    public bool isTouchObstcale;
    public Transform target;
    public LayerMask layerMask;
    public EnemyStat estat;
    private void Awake()
    {
        if (lineOfRay == null) { lineOfRay = this; }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, target.position,layerMask);
        if(hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "obstacle")
            {
                Debug.DrawLine(transform.position, target.position, Color.red);
                isTouchObstcale = true;
            }
            else if(hit.collider.gameObject.tag == "Enemy" && BulletConnect.bulletConnect.isConnected)
            {
                Debug.DrawLine(transform.position, target.position, Color.blue);
                estat = hit.collider.gameObject.GetComponent<EnemyStat>();
                estat.health -= 10 * Time.deltaTime;
                //Instantiate(laserParticle, hit.collider.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.DrawLine(transform.position, target.position, Color.green);
                isTouchObstcale = false;
            }
        }
    }
}
