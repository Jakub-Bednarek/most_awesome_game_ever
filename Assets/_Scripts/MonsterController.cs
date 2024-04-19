using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Transform player;
    public int health = 1;
    public float speed = 5f;
    void Update()
    {

        #region Move

        var target = gameObject.transform.position;
        target.z = 114;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, 5f * Time.deltaTime);
        
        #endregion

        #region Dead

        if (Vector3.Distance(gameObject.transform.position, target) < 1f)
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif

        #endregion
    }
}
