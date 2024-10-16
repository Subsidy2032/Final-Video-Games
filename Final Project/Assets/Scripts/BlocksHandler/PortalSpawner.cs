using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] float holeDuration = 5f;
    [SerializeField] float minSpawnTime = 3f;
    [SerializeField] float maxSpawnTime = 8f;
    [SerializeField] float probabilityForGreenPortal = 0.7f;

    // Blocks to get the position of all blocks that shouldn't be spawned
    [SerializeField] GameObject rightCeilingBlock;
    [SerializeField] GameObject upperRightWallBlock;

    private GameObject currentPortal;
    [SerializeField] GameObject originalBlockPrefab;

    void Start()
    {
        StartCoroutine(WaitAndStartSpawning());
    }

    // Added Quarantine to wait for the blocks to generate
    private IEnumerator WaitAndStartSpawning()
    {
        // Wait for a few seconds (you can adjust the time as needed)
        yield return new WaitForSeconds(2f);

        // Getting the needed blocks
        GetRightCieilingBlock();
        GetUpperRightWallBlock();

        // Start spawning holes
        StartCoroutine(SpawnHolesRoutine());
    }

    // Added function to get "rightCielingBlock"
    void GetRightCieilingBlock()
    {
        GameObject[] ceilingBlocks = GameObject.FindGameObjectsWithTag(ObjectTagsEnum.Ceiling.ToString());
        float maxX = float.MinValue;

        foreach (GameObject block in ceilingBlocks)
        {
            if (block.transform.position.x > maxX)
            {
                maxX = block.transform.position.x;
                rightCeilingBlock = block;
            }
        }
    }

    // Added function to get "UpperRightWallBlock"
    void GetUpperRightWallBlock()
    {
        GameObject[] rightWallBlocks = GameObject.FindGameObjectsWithTag(ObjectTagsEnum.RightWall.ToString());
        float maxY = float.MinValue;

        foreach (GameObject block in rightWallBlocks)
        {
            if (block.transform.position.y > maxY)
            {
                maxY = block.transform.position.y;
                upperRightWallBlock = block;
            }
        }
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
        // Changed from arrays to lists for easier manipulation
        List<GameObject> rightWalls = new List<GameObject>(GameObject.FindGameObjectsWithTag(ObjectTagsEnum.RightWall.ToString()));
        List<GameObject> leftWalls = new List<GameObject>(GameObject.FindGameObjectsWithTag(ObjectTagsEnum.LeftWall.ToString()));
        List<GameObject> ceiling = new List<GameObject>(GameObject.FindGameObjectsWithTag(ObjectTagsEnum.Ceiling.ToString()));

        float highestPositionWalls = upperRightWallBlock.transform.position.y;
        float highestPositionCieling = rightCeilingBlock.transform.position.x;

        // Finding walls that should be removed from the lists
        for (int i = rightWalls.Count - 1; i >= 0; i--)
        {
            float rightWallPosition = rightWalls[i].transform.position.y;
            float leftWallPosition = leftWalls[i].transform.position.y;
            float ceilingPoition = ceiling[i].transform.position.x;

            if (rightWallPosition >= (highestPositionWalls - 0.1) || rightWallPosition <= (-highestPositionWalls + 0.1))
            {
                rightWalls.RemoveAt(i);
            }

            if (leftWallPosition >= (highestPositionWalls - 0.1) || leftWallPosition <= (-highestPositionWalls + 0.1))
            {
                leftWalls.RemoveAt(i);
            }

            if (ceilingPoition >= (highestPositionCieling - 0.1) || ceilingPoition <= (-highestPositionCieling + 0.1))
            {
                ceiling.RemoveAt(i);
            }
        }

        List<GameObject> wallAndGroundObjects = new List<GameObject>();
        wallAndGroundObjects.AddRange(rightWalls);
        wallAndGroundObjects.AddRange(leftWalls);
        wallAndGroundObjects.AddRange(ceiling);
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
}
