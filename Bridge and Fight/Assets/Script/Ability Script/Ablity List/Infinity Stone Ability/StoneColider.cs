using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneColider : MonoBehaviour
{
    public static StoneColider stoneColider;

    public int curStoneValue;
    public int id;

    public GameObject[] stone;

    [SerializeField] float delayTime;

    protected float timerCountp1;
    protected float timerCountp2;

    CircleCollider2D cc;

    private void Awake()
    {
        if (stoneColider == null) { stoneColider = this; }
    }

    private void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        curStoneValue = InfinityStoneAbility.infinityStone.maxStoneValue;
        delayTime = Random.Range(10.0f, 21.0f);
    }

    private void Update()
    {

        abilityStoneActivated();

    }

    void abilityStoneActivated() 
    {
        if(AbilitySelector.abilitySelector.abilitySelected == 1) 
        {
            totalStone();
            if (curStoneValue > 3) { curStoneValue = 3; }
            if (curStoneValue <= InfinityStoneAbility.infinityStone.maxStoneValue)
            {
                if (id == 1)
                {
                    timerCountp1 += Time.deltaTime;
                    if (timerCountp1 >= delayTime)
                    {
                        timerCountp1 = 0f;
                        curStoneValue++;
                    }
                }
                if (id == 2)
                {
                    timerCountp2 += Time.deltaTime;
                    if (timerCountp2 >= delayTime)
                    {
                        timerCountp2 = 0f;
                        curStoneValue++;
                    }
                }

            }
            
            if (curStoneValue <= 0)
            {
                cc.enabled = false;
            }
            else if (curStoneValue > 0)
            {
                cc.enabled = true;
            }
        }
    }
    void totalStone() 
    {
        if (curStoneValue <= 2)
        {
            stone[0].SetActive(false);
        }
        else if (curStoneValue > 2)
        {
            stone[0].SetActive(true);
        }
        if (curStoneValue <= 1)
        {
            stone[1].SetActive(false);
        }
        else if (curStoneValue > 1)
        {
            stone[1].SetActive(true);
        }
        if (curStoneValue <= 0)
        {
            stone[2].SetActive(false);
        }
        else if (curStoneValue > 0)
        {
            stone[2].SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Normal Enemy") 
        {
            timerCountp1 = 0f;
            timerCountp2 = 0f;
            if (curStoneValue > 0) 
            {
                curStoneValue--;
            }
        }
        if(collision.gameObject.tag=="Medium Enemy") 
        {
            timerCountp1 = 0f;
            timerCountp2 = 0f;
            if (curStoneValue > 0)
            {
                curStoneValue-=2;
            }
        }

       
    }
}
