using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterCollectHandling : MonoBehaviour
{
    PlayerBoosterCollectChannel playerBoosterCollectChannel;

    // Start is called before the first frame update
    void Start()
    {
        Beacon beacon = Beacon.GetInstance();
        playerBoosterCollectChannel = beacon.playerBoosterCollectChannel;
        playerBoosterCollectChannel.CollisionDetected += improveJump;
    }

    void improveJump(GameObject player)
    {
        player.GetComponent<PlayerMovement>().jumpAmount = 10;
    }
}
