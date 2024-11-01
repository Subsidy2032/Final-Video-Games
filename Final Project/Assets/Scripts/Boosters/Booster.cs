using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] public SO_Booster sO_Booster;

    void Start()
    {
        if (sO_Booster != null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sO_Booster.boosterSprite;
        }
    }
}
