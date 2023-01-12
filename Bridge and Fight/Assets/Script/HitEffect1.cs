using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect1 : MonoBehaviour
{
    public static HitEffect1 he;
     #region Datamembers

        #region Editor Settings

        [Tooltip("Material to switch to during the flash.")]
        [SerializeField] private Material flashMaterial;

        [Tooltip("Duration of the flash.")]
        [SerializeField] private float duration;

        #endregion
        #region Private Fields

        // The SpriteRenderer that should flash.
        private SpriteRenderer spriteRenderer;
        
        // The material that was in use, when the script started.
        private Material originalMaterial;

        // The currently running coroutine.
        private Coroutine flashRoutine;

        #endregion

        #endregion


        #region Methods

        #region Unity Callbacks

        void Start()
        {
            // Get the SpriteRenderer to be used,
            // alternatively you could set it from the inspector.
            spriteRenderer = GetComponent<SpriteRenderer>();

            // Get the material that the SpriteRenderer uses, 
            // so we can switch back to it after the flash ended.
            originalMaterial = spriteRenderer.material;
        }

        #endregion
        void Update()
        {
            if(Input.GetMouseButton(0))
        {
            Flash();
        }
        }
        public void Flash()
        {
            StartCoroutine(FlashRoutine());
        }

        private IEnumerator FlashRoutine()
        {
            while (true)
            {
                spriteRenderer.material = flashMaterial;
    
                yield return new WaitForSeconds(duration);
    
                spriteRenderer.material = originalMaterial;
            }
        }

        #endregion
}
