using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace _Scripts
{
    public class GunController : MonoBehaviour
    {
        public GameObject bullet;
        public Camera camera;
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 launchPosition = Camera.main.transform.position + Camera.main.transform.forward * 100f;
                GameObject duplicateObject = Instantiate(bullet);
                duplicateObject.GetComponent<BulletController>().isMain = false;
                duplicateObject.GetComponent<BulletController>().target = launchPosition;
                duplicateObject.transform.position = bullet.transform.position;
            }
        }
    }
}