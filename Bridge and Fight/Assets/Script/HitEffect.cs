using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{

    public static HitEffect hitEffect;


    [SerializeField] private Material flashMaterial;




    [SerializeField] private float duration;




    private SpriteRenderer spriteRenderer;


    private Material originalMaterial;

    private Coroutine flashRoutine;

    private void Awake()
    {
        hitEffect = this;
       
    }



    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }
    
    public void flashOut()
    {
     
        if (flashRoutine != null) 
        {
            StopCoroutine(flashingObject());
        }
        
        flashRoutine= StartCoroutine(flashingObject());
    }
    
    IEnumerator flashingObject() 
    {
     

        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;

        flashRoutine = null;
  
    }
}
