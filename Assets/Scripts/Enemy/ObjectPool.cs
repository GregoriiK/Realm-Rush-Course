using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] [Range(0.1f , 30f)] float timeToNextEnemy = 1f;
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0, 50)] int poolSize = 5;

    GameObject[] pool;
    void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        foreach (GameObject instance in pool)
        {
            if (!instance.activeSelf)
            {
                instance.SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(timeToNextEnemy);
        }
    }

}
