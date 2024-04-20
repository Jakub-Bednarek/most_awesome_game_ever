using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] List<FollowPlayer> enemiesToSpawn;
    [SerializeField] bool isMonsterSpawned = false;
    [SerializeField] float monsterSpawnChangeInPercent = 25.0f;
    private Player player;
    private float delay = 3.0f;
    private float timePassed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(ShouldMonsterBeSpawned() && !isMonsterSpawned)
        {
            SpawnRandomMonster();
        }
    }

    private bool ShouldMonsterBeSpawned()
    {
        if (timePassed > delay)
        {
            SpawnRandomMonster();
            timePassed -= delay;

            return Random.Range(0, 100) > monsterSpawnChangeInPercent;
        }

        return false;
    }

    private void SpawnRandomMonster()
    {
        if (!isMonsterSpawned)
        {
            isMonsterSpawned = true;
            int monsterIndexToSpawn = Random.Range(0, enemiesToSpawn.Count);
            Instantiate(enemiesToSpawn[monsterIndexToSpawn], player.transform.position, Quaternion.identity);
        }
    }
}
