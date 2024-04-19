using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace _Scripts
{
    public class WaterCotroller : MonoBehaviour, IInteractable
    {
        public void Interact(FPSController player)
        {
            var amount = player.transform.Find("Main Camera").gameObject.GetComponent<DotMatrixEffect>().amount + 20;
            if (amount >= 200)
                amount = 200;

            player.transform.Find("Main Camera").gameObject.GetComponent<DotMatrixEffect>().amount = amount;
            gameObject.SetActive(false);
        }
    }
}
