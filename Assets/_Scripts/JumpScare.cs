using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject monster;
    public float moveSpeed = 5f;
    private Vector3 _targetPosition;
    private Vector3 _monsterPosition;

    private void Start()
    {
        _monsterPosition = monster.transform.position;
    }

    private void OnTriggerEnter(Collider player)
    {
        monster.transform.position = _monsterPosition;
        monster.SetActive(true);
        Vector3 colliderPosition = player.transform.position;
        _targetPosition = new Vector3(colliderPosition.x, monster.transform.position.y, colliderPosition.z);
    }

    private void Update()
    {
        if (Vector3.Distance(monster.transform.position, _targetPosition) > 2.0)
            monster.transform.position = Vector3.MoveTowards(monster.transform.position, _targetPosition, moveSpeed * Time.deltaTime);
        else
            monster.SetActive(false);
    }
}
