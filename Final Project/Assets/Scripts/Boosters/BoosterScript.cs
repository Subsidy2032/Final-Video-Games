using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterScript : MonoBehaviour
{
    [SerializeField] public SO_Booster sO_Booster;
    private PlayerBoosterCollectChannel playerBoosterCollectChannel;

    void Start()
    {
        if (sO_Booster != null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sO_Booster.boosterSprite;
        }

        Beacon beacon = Beacon.GetInstance();
        playerBoosterCollectChannel = beacon.playerBoosterCollectChannel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTagsEnum.Player.ToString()))
        {
            Debug.Log("Collided");
            playerBoosterCollectChannel.InvokeCollisionDetected(collision.gameObject);
            // DoSomethingWithPlayerEvent();
            Destroy(this.gameObject);
        }
    }
}
