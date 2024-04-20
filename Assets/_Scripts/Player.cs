using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("monster"))
        {
            Debug.Log("Holy fuckers");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
