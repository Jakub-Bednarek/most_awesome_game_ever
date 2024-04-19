using System.Collections;
using System.Collections.Generic;
using _Scripts;
using TMPro;

using UnityEngine;
public enum Stages{Stage1, Stage2, Stage3, Stage4, Stage5}
public class ZombieGameController : MonoBehaviour
{
    public Stages stages;
    public bool isStarted;
    public GameObject monsterModel;
    private bool isSpawned = false;
    public Transform _player;
    public Door _door;
    public Canvas canvas;
    private void OnTriggerEnter(Collider player)
    {
        if (!isStarted)
            isStarted = true;
    }

    void Update()
    {
        #region Kill

        if (Input.GetButtonDown("Fire1") && isStarted)
        {
            Ray ray = new Ray(_player.position, _player.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f))
            {
                if (hitInfo.collider.CompareTag("monster"))
                {
                    var monster = hitInfo.transform.GetComponent<MonsterController>();
                    monster.health--;
                    if (monster.health == 0)
                        Destroy(hitInfo.transform.gameObject, 0.2f);
                }
            }
        }

        #endregion

        #region Spawn

        if (isStarted && !isSpawned)
        {
            isSpawned = true;
            if (stages == Stages.Stage1)
                SpawnMonster(10, 1);
            else if (stages == Stages.Stage2)
                SpawnMonster(15, 1);
            else if (stages == Stages.Stage3)
                SpawnMonster(20, 1);
        }

        #endregion

        #region Change Stage

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("monster");
        if (objectsWithTag.Length == 0 && isSpawned && stages != Stages.Stage3)
        {
            isSpawned = false;
            if (stages == Stages.Stage1)
                stages = Stages.Stage2;
            else if (stages == Stages.Stage2)
                stages = Stages.Stage3;
        } 
        else if (objectsWithTag.Length == 0 && isSpawned && _door.isLocked)
        {
            _door.isLocked = false;
            canvas.gameObject.SetActive(true);
            canvas.transform.Find("TextMain").GetComponent<TextMeshProUGUI>().text = "Udało się";
            canvas.transform.Find("TextSub").GetComponent<TextMeshProUGUI>().text = "Drzwi otwarte";
        }

        #endregion
        
    }

    void SpawnMonster(int numberOfObjects, int hp)
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            var x = Random.Range(38f, 90f);
            var location = new Vector3(x, 6.67f, 77.0f);
            GameObject monster = Instantiate(monsterModel, location, Quaternion.identity);
            monster.tag = "monster";
            MonsterController monsterController = monster.GetComponent<MonsterController>();
            monsterController.health = hp;
            monsterController.player = _player;
        }
    }
}
