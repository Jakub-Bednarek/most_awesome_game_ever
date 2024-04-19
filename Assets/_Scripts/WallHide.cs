using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class WallHide : MonoBehaviour, IInteractable
    {
        public GameObject paper;
        public GameObject wall;
        public GameObject teleportUI;
        public GameObject weapon;
        public void Interact(FPSController player)
        {
            player.canTeleport = false;
            paper.SetActive(false);
            wall.SetActive(false);
            weapon.SetActive(true);
            teleportUI.SetActive(false);
        }
    }    
}

