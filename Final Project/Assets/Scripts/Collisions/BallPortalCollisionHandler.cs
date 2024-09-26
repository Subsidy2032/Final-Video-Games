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

        if (thisCollider != null && thisCollider.isTrigger) 
        {
            if (collision.CompareTag("Ball") && collision.isTrigger)
            {
                ballHoleCollisionChannel.InvokeCollisionDetected(collision.gameObject, gameObject.tag);
            }
        }
        
    }
}