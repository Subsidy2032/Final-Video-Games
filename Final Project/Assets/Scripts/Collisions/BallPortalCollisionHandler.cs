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

        // Getting the sprite rendered of the block 
        SpriteRenderer blockSpriteRenderer = GetComponent<SpriteRenderer>();

        if (thisCollider != null && thisCollider.isTrigger) 
        {
            if (collision.CompareTag("Ball") && collision.isTrigger)
            {
                ballHoleCollisionChannel.InvokeCollisionDetected(collision.gameObject, gameObject.tag, ColorToString(blockSpriteRenderer.color));
            }
        }
        
    }


    private string ColorToString(Color color)
    {
        if (color == Color.red) return "red";
        if (color == Color.green) return "green";

        return $"Color({color.r}, {color.g}, {color.b}, {color.a})";
    }
}