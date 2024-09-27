using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterCollectHandling : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTagsEnum.Booster.ToString()))
        {
            this.GetComponent<PlayerMovement>().jumpAmount = 10;
            Destroy(collision.gameObject);
        }
    }
}
