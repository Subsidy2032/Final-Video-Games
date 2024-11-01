using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] public SO_Ball sO_Ball;

    void Start()
    {
        if (sO_Ball != null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sO_Ball.ballSprite;
        }

        Transform transform = GetComponent<Transform>();
        transform.localScale = new Vector3(0.2f, 0.2f, 1f);
    }
}