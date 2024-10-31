using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterCollectHandling : MonoBehaviour
{
    [SerializeField] private float boostDuration = 5f;
    [SerializeField] private float jumpMultiplier = 2f;

    private float originalJumpAmount;

    private void Start()
    {
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        originalJumpAmount = playerMovement.jumpAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTagsEnum.Booster.ToString()))
        {
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            playerMovement.jumpAmount *= jumpMultiplier;
            Destroy(collision.gameObject);
            StartCoroutine(ResetJumpAmountAfterDelay(playerMovement));
        }
    }

    private IEnumerator ResetJumpAmountAfterDelay(PlayerMovement playerMovement)
    {
        yield return new WaitForSeconds(boostDuration);
        playerMovement.jumpAmount = originalJumpAmount;
    }
}
