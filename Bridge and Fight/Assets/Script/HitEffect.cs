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

    // The SpriteRenderer that should flash.
    private SpriteRenderer spriteRenderer;

    // The material that was in use, when the script started.
    private Material originalMaterial;

    private Coroutine flashRoutine;

    public bool ye = false;

    private void Awake()
    {
        hitEffect = this;
        //flashMaterial = Material.Instantiate(flashMaterial);
    }

   

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
        StartCoroutine(flashingObject());
    }

    void Update()
    {
    }

    public void flashOut()
    {
        StartCoroutine(flashingObject());
    }

    IEnumerator flashingObject() 
    {
        while (true)
        {
            spriteRenderer.material = flashMaterial;
            //print("ok");
            yield return new WaitForSeconds(duration);
            //print("kena");
            spriteRenderer.material = originalMaterial;
            yield return new WaitForSeconds(duration);
        }
    }
}
