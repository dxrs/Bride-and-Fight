using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{

    public static HitEffect hitEffect;

    [Tooltip("Material to switch to during the flash.")]
    [SerializeField] private Material flashMaterial;



    [Tooltip("Duration of the flash.")]
    [SerializeField] private float duration;

    [SerializeField] int jokowi;

    // The SpriteRenderer that should flash.
    private SpriteRenderer spriteRenderer;

    // The material that was in use, when the script started.
    private Material originalMaterial;

    private Coroutine flashRoutine;

    private void Awake()
    {
        hitEffect = this;
        //flashMaterial = Material.Instantiate(flashMaterial);
    }

   

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }
    private void Update()
    {
        if (jokowi == 0) 
        {
            spriteRenderer.material = originalMaterial;
        }
        else 
        {
            spriteRenderer.material = flashMaterial;
        }
    }
    public void flashOut()
    {

        if (flashRoutine != null) 
        {
            //StopCoroutine(flashingObject());
        }
        StartCoroutine(flashingObject());

    }
    
    IEnumerator flashingObject() 
    {
        //Material materialSementara = spriteRenderer.material;
        
        jokowi = 1;
        yield return new WaitForSeconds(0.000001f);
        jokowi = 0;
        
        //flashRoutine = null;
        //yield return StartCoroutine(flashingObject());
    }
}
