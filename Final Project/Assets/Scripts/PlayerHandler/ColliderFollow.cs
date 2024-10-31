using UnityEngine;

public class ColliderFollow : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        transform.position = playerTransform.position;
    }
}