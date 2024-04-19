using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public bool isMain = false;
    public Vector3 target;
    void Update()
    {
        if (!isMain)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, 30f * Time.deltaTime);
            Destroy(gameObject, 1f);
        }
    }
}
