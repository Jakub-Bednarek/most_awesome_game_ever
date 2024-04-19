using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace _Scripts
{
    public enum Abilities{Teleport}
    public class UnlockAbility : MonoBehaviour, IInteractable
    {
        public Canvas abilityCanvas;
        public Abilities ability;
        public Canvas UI;
        public void Interact(FPSController player)
        {
            // abilityText

            if (ability == Abilities.Teleport)
            {
                abilityCanvas.transform.Find("TextMain").GetComponent<TextMeshProUGUI>().text = "Odblokowano Teleport";
                abilityCanvas.transform.Find("TextSub").GetComponent<TextMeshProUGUI>().text = "Kliknij R";
                UI.transform.Find("TeleportAbility").gameObject.SetActive(true);
                player.canTeleport = true;
            }
            abilityCanvas.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

