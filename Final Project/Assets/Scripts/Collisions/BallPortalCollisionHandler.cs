using UnityEngine;

public class BallPortalCollisionHandler : MonoBehaviour
{
    private BallHoleCollisionChannel ballHoleCollisionChannel;

    void Start()
    {
        Beacon beacon = Beacon.GetInstance();
        ballHoleCollisionChannel = beacon.ballHoleCollisionChannel;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Collider2D thisCollider = GetComponent<Collider2D>();

        SpriteRenderer blockSpriteRenderer = GetComponent<SpriteRenderer>();

        if (thisCollider != null && thisCollider.isTrigger) 
        {
            if (collision.CompareTag(ObjectTagsEnum.Ball.ToString()) && collision.isTrigger && IsOutOfBounds(collision.gameObject, gameObject.tag))
            {
                ballHoleCollisionChannel.InvokeCollisionDetected(collision.gameObject, gameObject.tag, ColorToString(blockSpriteRenderer.color));
            }
        }
        
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

    private string ColorToString(Color color)
    {
        if (color == Color.red) return "red";
        if (color == Color.green) return "green";

        return $"Color({color.r}, {color.g}, {color.b}, {color.a})";
    }
}