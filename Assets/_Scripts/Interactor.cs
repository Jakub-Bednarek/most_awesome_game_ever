using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact(FPSController player);
}
public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public FPSController player;
    public float InteractRange;
    void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact(player);
                }
            }

        }    
    }
}
