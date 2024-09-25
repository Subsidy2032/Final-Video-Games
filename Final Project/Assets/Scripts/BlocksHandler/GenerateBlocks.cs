using UnityEngine;

public class GenerateBlocks : MonoBehaviour
{
    public GameObject blockSegmentPrefab;
    public float blockThickness = 1f;
    public int segmentsPerBlock = 5;

    void Start()
    {
        Camera cam = Camera.main;
        float screenHeight = 2f * cam.orthographicSize;
        float screenWidth = screenHeight * cam.aspect;

        CreateSegmentedWall(new Vector2(0, screenHeight / 2f), screenWidth, blockThickness, true); // Top block
        CreateSegmentedWall(new Vector2(0, -screenHeight / 2f), screenWidth, blockThickness, true); // Bottom block
        CreateSegmentedWall(new Vector2(-screenWidth / 2f, 0), screenHeight, blockThickness , false); // Left block
        CreateSegmentedWall(new Vector2(screenWidth / 2f, 0), screenHeight, blockThickness, false); // Right block
    }

    void CreateSegmentedWall(Vector2 position, float wallLength, float thickness, bool isHorizontal)
    {
        float segmentLength = wallLength / segmentsPerBlock;

        for (int i = 0; i < segmentsPerBlock; i++)
        {
            Vector2 segmentPosition;

            if (isHorizontal)
            {
                float xPos = -wallLength / 2f + (i * segmentLength) + segmentLength / 2f;
                segmentPosition = new Vector2(xPos, position.y);
            }
            else
            {
                float yPos = -wallLength / 2f + (i * segmentLength) + segmentLength / 2f;
                segmentPosition = new Vector2(position.x, yPos);
            }

            GameObject wallSegment = Instantiate(blockSegmentPrefab, segmentPosition, Quaternion.identity);
            wallSegment.transform.localScale = isHorizontal ? new Vector2(segmentLength, thickness) : new Vector2(thickness, segmentLength);

            if (isHorizontal)
            {
                if (position.y < 0)
                    wallSegment.tag = ObjectTagsEnum.Ground.ToString();

                else
                    wallSegment.tag = ObjectTagsEnum.Ceiling.ToString();
            }
                
            else
            {
                if (position.x < 0)
                    wallSegment.tag = ObjectTagsEnum.LeftWall.ToString();

                else
                    wallSegment.tag = ObjectTagsEnum.RightWall.ToString();
            }
        }
    }
}
