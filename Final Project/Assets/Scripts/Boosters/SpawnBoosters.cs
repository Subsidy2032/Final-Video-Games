using System.Collections;
using UnityEngine;

public class SpawnBoosters : MonoBehaviour
{
    public GameObject boosterPrefab;
    public Transform pointA;
    public Transform pointB;
    public float spawnInterval = 3f;

    [SerializeField] private float boosterLifetime = 5f;

    void Start()
    {
        StartCoroutine(SpawnBooster());
    }

    IEnumerator SpawnBooster()
    {
        float xPos = Random.Range(pointA.position.x, pointB.position.x);
        Vector2 spawnPosition = new Vector2(xPos, pointA.position.y);
        GameObject booster = Instantiate(boosterPrefab, spawnPosition, Quaternion.identity);

        Destroy(booster, boosterLifetime);

        yield return new WaitForSeconds(spawnInterval);

        StartCoroutine(SpawnBooster());
    }
}
