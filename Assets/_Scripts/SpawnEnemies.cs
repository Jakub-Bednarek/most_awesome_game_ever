using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] List<FollowPlayer> enemiesToSpawn;
    [SerializeField] float monsterSpawnChangeInPercent = 25.0f;
    [SerializeField] Player player;
    [SerializeField] bool isLevelEligibleForSpawningMonsters = false;
    private readonly float delay = 3.0f;
    private float timePassed = 0.0f;
    private bool isMonsterSpawned = false;
    private FollowPlayer spawnedMonster = null;

    void OnEnable()
    {
        FPSController.levelChangeEvent.AddListener(OnLevelChange);
    }

    void OnDisable()
    {
        FPSController.levelChangeEvent.RemoveListener(OnLevelChange);
    }

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

    private void OnLevelChange(Level level)
    {
        if(level == Level.REALITY)
        {
            isLevelEligibleForSpawningMonsters = false;
            ResetPropertiesOnSafeLevelChange();
        }
        else if (level == Level.OTHER_REALM)
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

        return player.transform.position + new Vector3(xOffset, -2.0f, zOffset);
    }

    private void SpawnRandomMonster()
    {
        if (!isMonsterSpawned)
        {
            isMonsterSpawned = true;

            int monsterIndexToSpawn = Random.Range(0, enemiesToSpawn.Count);
            spawnedMonster = Instantiate(enemiesToSpawn[monsterIndexToSpawn], GenerateRandomMonsterPosition(), enemiesToSpawn[monsterIndexToSpawn].transform.rotation);
            spawnedMonster.lifeDurationInSeconds = Random.Range(10.0f, 25.0f);
            spawnedMonster.onMonsterDeathEvent.AddListener(ResetStateAfterMonsterDeath);
        }
    }

    private void ResetStateAfterMonsterDeath()
    {
        isMonsterSpawned = false;
    }
}
