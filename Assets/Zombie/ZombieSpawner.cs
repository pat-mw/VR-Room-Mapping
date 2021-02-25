
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{

    public GameObject zombiePrefab;

    [SerializeField] Transform target;
    [SerializeField] int spawnCount = 10;
    [SerializeField] float spawnRadius = 5f;
    [SerializeField] float maxDelay = 10f;

    private void Start()
    {
        SpawnZombies(spawnCount);
    }

    private void SpawnZombies(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            StartCoroutine(InstantiateZombie());
        }
    }

    private IEnumerator InstantiateZombie()
    {
        yield return new WaitForSeconds(Random.Range(0f, maxDelay));

        GameObject zombie = Instantiate(zombiePrefab, transform);
        zombie.transform.position += RandomInitialOffset();
        zombie.GetComponent<Zombie>().targetTransform = target;
    }

    private Vector3 RandomInitialOffset()
    {
        Vector3 offset = Random.insideUnitSphere * spawnRadius;
        offset.y = 0;
        return offset;
    }
}

