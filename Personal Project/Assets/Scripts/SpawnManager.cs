using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemiesPrefab;
    public GameObject alliesPrefab;

    public float minionInterval;
    private float startDelay = 0;

    private void Start()
    {
        InvokeRepeating("SpawnMinions", startDelay, minionInterval);
    }

    void SpawnMinions()
    {
        Vector3 enemySpawnPos = new Vector3(-80, 0, 0);
        Vector3 allySpawnPos = new Vector3(80, 0, 0);

        Instantiate(enemiesPrefab, enemySpawnPos, enemiesPrefab.transform.rotation);
        Instantiate(alliesPrefab, allySpawnPos, alliesPrefab.transform.rotation);
    }
}