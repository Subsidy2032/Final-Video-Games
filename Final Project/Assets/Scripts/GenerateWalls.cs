using UnityEngine;

public class GenerateWalls : MonoBehaviour
{
    public GameObject wallSegmentPrefab; // Assign your wall segment prefab here.
    public float wallThickness = 1f; // Thickness of the walls.
    public int segmentsPerWall = 5; // Number of segments per wall.

    void Start()
    {
        // Get the camera's boundaries in world units
        Camera cam = Camera.main;
        float screenHeight = 2f * cam.orthographicSize;
        float screenWidth = screenHeight * cam.aspect;

        // Create segmented walls
        CreateSegmentedWall(new Vector2(0, screenHeight / 2f), screenWidth, wallThickness, true); // Top wall
        CreateSegmentedWall(new Vector2(0, -screenHeight / 2f), screenWidth, wallThickness, true); // Bottom wall
        CreateSegmentedWall(new Vector2(-screenWidth / 2f, 0), screenHeight, wallThickness , false); // Left wall
        CreateSegmentedWall(new Vector2(screenWidth / 2f, 0), screenHeight, wallThickness, false); // Right wall
    }

    void CreateSegmentedWall(Vector2 position, float wallLength, float thickness, bool isHorizontal)
    {
        float segmentLength = wallLength / segmentsPerWall;

        for (int i = 0; i < segmentsPerWall; i++)
        {
            // Calculate the position for each segment
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

            // Instantiate the segment
            GameObject wallSegment = Instantiate(wallSegmentPrefab, segmentPosition, Quaternion.identity);
            wallSegment.transform.localScale = isHorizontal ? new Vector2(segmentLength, thickness) : new Vector2(thickness, segmentLength);

            if (isHorizontal && position.y < 0)
                wallSegment.tag = "Ground";
        }
    }
}
