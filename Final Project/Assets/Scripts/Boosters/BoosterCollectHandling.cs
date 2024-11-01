using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterCollectHandling : MonoBehaviour
{
    [SerializeField] private float boostDuration = 5f;
    [SerializeField] private float jumpMultiplier = 2f;
    private float originalJumpAmount;

    [SerializeField] private int secondsToAdd = 3;

    private AddTimeChannel addTimeChannel;
    private bool hasCollectedBooster = false;

    private void Start()
    {
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        originalJumpAmount = playerMovement.jumpAmount;

        addTimeChannel = Beacon.GetInstance().addTimeChannel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasCollectedBooster)
            return;

        Booster booster = collision.GetComponent<Booster>();

        if (booster != null && booster.sO_Booster.boostType != null)
        {
            if (booster.sO_Booster.boostType == "Jump")
            {
                PlayerMovement playerMovement = GetComponent<PlayerMovement>();
                playerMovement.jumpAmount *= jumpMultiplier;
                Destroy(collision.gameObject);
                StartCoroutine(ResetJumpAmountAfterDelay(playerMovement));
            }

            else if (booster.sO_Booster.boostType == "Time")
            {
                addTimeChannel.BoosterCollected(secondsToAdd);
                Destroy(collision.gameObject);
                hasCollectedBooster = true;
                StartCoroutine(ResetBool());
            }
        }
    }

    private IEnumerator ResetJumpAmountAfterDelay(PlayerMovement playerMovement)
    {
        yield return new WaitForSeconds(boostDuration);
        playerMovement.jumpAmount = originalJumpAmount;
    }

    private IEnumerator ResetBool()
    {
        yield return new WaitForSeconds(1f);
        hasCollectedBooster = false;
    }
}
