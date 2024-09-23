using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] float holeDuration = 5f;
    [SerializeField] float minSpawnTime = 3f;
    [SerializeField] float maxSpawnTime = 8f;
    [SerializeField] float probabilityForGreenPortal = 0.7f;

    private GameObject currentPortal;
    [SerializeField] GameObject originalBlockPrefab;

    void Start()
    {
        StartCoroutine(SpawnHolesRoutine());
    }

    private IEnumerator SpawnHolesRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            SpawnHole();
            yield return new WaitForSeconds(holeDuration);

            CloseHole();
        }
    }

    private void SpawnHole()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag(ObjectTag.Block.ToString());
        GameObject[] grounds = GameObject.FindGameObjectsWithTag(ObjectTag.Ground.ToString());

        List<GameObject> wallAndGroundObjects = new List<GameObject>();
        wallAndGroundObjects.AddRange(blocks);
        wallAndGroundObjects.AddRange(grounds);
        GameObject[] allBlocks = wallAndGroundObjects.ToArray();

        int randomIndex = Random.Range(0, allBlocks.Length);

        currentPortal = allBlocks[randomIndex];
        Collider2D portalColider = currentPortal.GetComponent<Collider2D>();
        SpriteRenderer portalSprite = currentPortal.GetComponent<SpriteRenderer>();

        if (portalColider != null)
        {
            portalColider.isTrigger = true;
        }

        if (portalSprite != null)
        {
            int portalColorNumber = (Random.value < probabilityForGreenPortal) ? 0 : 1;

            if(portalColorNumber == 0)
            {
                portalSprite.color = Color.green;
            }
            
            else
            {
                portalSprite.color = Color.red;
            }
        }
    }

    private void CloseHole()
    {
        Collider2D portalColider = currentPortal.GetComponent<Collider2D>();
        SpriteRenderer portalSprite = currentPortal.GetComponent<SpriteRenderer>();

        if (portalColider != null)
        {
            portalColider.isTrigger = false;
        }

        if (portalSprite != null)
        {
            portalSprite.color = Color.white;
        }
    }

    public enum ObjectTag
    {
        Block,
        Ground
    }
}
