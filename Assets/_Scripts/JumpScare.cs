using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts
{
    public class JumpScare : MonoBehaviour
    {
        public GameObject monster;
        public float moveSpeed = 5f;
        public GameObject _player;
        public Canvas blackScreen;
        public GameObject abilityBack;
        public Door door;
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

        void Update()
        {
            if (Vector3.Distance(monster.transform.position, _targetPosition) > 0)
                monster.transform.position = Vector3.MoveTowards(monster.transform.position, _targetPosition, moveSpeed * Time.deltaTime);
            else if (Vector3.Distance(monster.transform.position, _targetPosition) < 2.0 && monster.activeSelf)
            {
                _player.GetComponent<FPSController>().canTeleport = _player.GetComponent<FPSController>().canMove = false;
                StartCoroutine(HideBlackScreen());
                Vector3 location = new Vector3(-9.2f, -10f, -0.7f);
                _player.transform.position = location;
                Physics.SyncTransforms();
            }
        }
        private System.Collections.IEnumerator HideBlackScreen()
        {
            blackScreen.transform.Find("BlackScreen").GameObject().SetActive(true);
            _player.transform.Find("Main Camera").gameObject.GetComponent<DotMatrixEffect>().amount = 200;
            yield return new WaitForSeconds(10);
            blackScreen.transform.Find("BlackScreen").GameObject().SetActive(false);
            blackScreen.transform.Find("TeleportAbility").GameObject().SetActive(false);
            gameObject.SetActive(false);
            monster.SetActive(false);
            abilityBack.SetActive(true);
            _player.GetComponent<FPSController>().canTeleport = _player.GetComponent<FPSController>().canMove = true;
            door.isLocked = false;
        }
    }
}

