using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedFunctions : MonoBehaviour
{
    private static SharedFunctions instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public static SharedFunctions GetInstance()
    {
        return instance;
    }

    public bool IsOutOfBounds(GameObject ball, string tag)
    {
        GameObject block = GameObject.FindWithTag(tag);
        float ballXPosition = ball.transform.position.x;
        float ballYPosition = ball.transform.position.y;

        float blockXPosition = block.transform.position.x;
        float blockYPosition = block.transform.position.y;

        if (tag == ObjectTagsEnum.LeftWall.ToString() && ballXPosition < blockXPosition)
            return true;

        if (tag == ObjectTagsEnum.RightWall.ToString() && ballXPosition > blockXPosition)
            return true;

        if (tag == ObjectTagsEnum.Ground.ToString() && ballYPosition < blockYPosition)
            return true;

        if (tag == ObjectTagsEnum.Ceiling.ToString() && ballYPosition > blockYPosition)
            return true;

        return false;
    }
}