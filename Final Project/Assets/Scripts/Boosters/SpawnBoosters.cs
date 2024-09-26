using System.Collections;
using UnityEngine;

public class SpawnBoosters : MonoBehaviour
{
    public GameObject boosterPrefab;
    public Transform pointA;
    public Transform pointB;
    public float spawnInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnBooster());
    }

    IEnumerator SpawnBooster()
    {
        while (true)
        {
            float xPos = Random.Range(pointA.position.x, pointB.position.x);
            Vector2 spawnPosition = new Vector2(xPos, pointA.position.y);
            Instantiate(boosterPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
