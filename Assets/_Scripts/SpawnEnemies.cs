using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] List<FollowPlayer> enemiesToSpawn;
    [SerializeField] FollowPlayer spawnedMonster = null;
    [SerializeField] bool isMonsterSpawned = false;
    [SerializeField] float monsterSpawnChangeInPercent = 25.0f;
    private Player player;
    private float delay = 3.0f;
    private float timePassed = 0.0f;
    [SerializeField] bool isLevelEligibleForSpawningMonsters = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLevelEligibleForSpawningMonsters)
        {
            return;
        }

        timePassed += Time.deltaTime;
        if(ShouldMonsterBeSpawned())
        {
            SpawnRandomMonster();
        }
    }

    private void OnLevelChange(int level)
    {
        if(level == 0)
        {
            isLevelEligibleForSpawningMonsters = false;
            ResetPropertiesOnSafeLevelChange();
        }
        else
        {
            isLevelEligibleForSpawningMonsters = true;
        }
    }

    private void ResetPropertiesOnSafeLevelChange()
    {
        timePassed = 0.0f;

        if(spawnedMonster != null)
        {
            Destroy(spawnedMonster.gameObject);
            isMonsterSpawned = false;
        }
    }

    private bool ShouldMonsterBeSpawned()
    {
        if (timePassed < delay)
        {
            return false;
        }

        timePassed -= delay;
        return !isMonsterSpawned && Random.Range(0, 100) < monsterSpawnChangeInPercent;

    }

    private Vector3 GenerateRandomMonsterPosition()
    {
        float xOffset = Random.Range(8.0f, 30.0f); 
        float zOffset = Random.Range(8.0f, 30.0f); 

        return player.transform.position + new Vector3(xOffset, 0.0f, zOffset);
    }

    private void SpawnRandomMonster()
    {
        if (!isMonsterSpawned)
        {
            isMonsterSpawned = true;
            int monsterIndexToSpawn = Random.Range(0, enemiesToSpawn.Count);
            Instantiate(enemiesToSpawn[monsterIndexToSpawn], GenerateRandomMonsterPosition(), Quaternion.identity);
        }
    }
}
