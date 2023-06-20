using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int[] waveSizes = { 5, 10, 40 };
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 10f;

    private int currentWave = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWave < waveSizes.Length)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            for (int i = 0; i < waveSizes[currentWave]; i++)
            {
                SpawnZombie();
                yield return new WaitForSeconds(1f);
            }

            currentWave++;
        }
    }

    private void SpawnZombie()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        var zombie = Instantiate(zombiePrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
        zombie.SetActive(true);
    }
}