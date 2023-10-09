using System.Collections;
using UnityEngine;
public class SpawnEnemy : MonoBehaviour
{
     public GameObject[] enemyPrefab;
    [SerializeField]float minX, maxX, minZ, maxZ;
    [SerializeField] float SpawnTime;
    [SerializeField] float yPos = 1.1f;
    [SerializeField] int maxEnemyCount;

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(SpawnTime);
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        int rand = Random.Range(0, enemyPrefab.Length);
        GameObject enemyToSpawn = enemyPrefab[rand];
        GameObject g = Instantiate(enemyToSpawn, randomPosition, Quaternion.identity).gameObject;
        g.transform.position = new Vector3(randomPosition.x, yPos, randomPosition.z);

        StartCoroutine(Spawner());
    }


    private void Start()
    {
            StartCoroutine(Spawner());
    }
}
