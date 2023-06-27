using System.Collections;
using UnityEngine;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public GameObject zombiePrefab2;
    public int[,] waveSizes = {{2, 0}, {8, 0}, {10, 2}, {15, 5}, {5, 10}, {10, 10}, {20, 20}, {50, 50}, {10000, 10000}};
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 10f;
    
    public TextMeshProUGUI  textWave;

    private int currentWave = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWave < waveSizes.Length - 1)
        {
            textWave.enabled = true;
            textWave.SetText("Vagues " + (currentWave + 1));
            yield return new WaitForSeconds(3f);
            textWave.enabled = false;
            
            yield return new WaitForSeconds(timeBetweenWaves);

            for (int i = 0; i < waveSizes[currentWave, 0]; i++)
            {
                SpawnZombie();
                yield return new WaitForSeconds(0.8f);
            }
            for (int i = 0; i < waveSizes[currentWave, 1]; i++)
            {
                SpawnZombie2();
                yield return new WaitForSeconds(0.4f);
            }

            currentWave++;
            
            textWave.SetText((currentWave + 1).ToString());
        }
    }

    private void SpawnZombie()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        var zombie = Instantiate(zombiePrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
        zombie.SetActive(true);
    }
    
    private void SpawnZombie2()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        var zombie = Instantiate(zombiePrefab2, spawnPoints[spawnPointIndex].position, Quaternion.identity);
        zombie.SetActive(true);
    }
}