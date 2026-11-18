using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour
{
float spawnInterval = 8f;
public GameObject enemyPrefab;
public Transform spawnPoint;

void Start()
{
    StartCoroutine(spawnEnemies(spawnInterval, enemyPrefab, spawnPoint));
}
private IEnumerator spawnEnemies(float interval, GameObject enemyPrefab, Transform spawnPoint)
{
    yield return new WaitForSeconds(interval);
    Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    spawnInterval = spawnInterval * 0.9f;
    StartCoroutine(spawnEnemies(interval, enemyPrefab, spawnPoint));
}
}
