using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Scripts
{
    public class AbilityTextCooldown : MonoBehaviour
    {
        public float cooldown = 10f;
        void OnEnable()
        {
            StartCoroutine(HideCanvasAfterDelay());
        }
        private System.Collections.IEnumerator HideCanvasAfterDelay()
        {
            // Wait for the specified delay
            yield return new WaitForSeconds(cooldown);

            // Hide the canvas
            gameObject.SetActive(false);
        }

        // Method to call when you want to reset the hide delay
        public void ResetHideDelay()
        {
            // Stop the coroutine if it's already running
            StopCoroutine(HideCanvasAfterDelay());

            // Restart the coroutine to hide the canvas after the delay
            StartCoroutine(HideCanvasAfterDelay());
        }
    }
}