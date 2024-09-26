using UnityEngine;

[CreateAssetMenu(fileName = "New Booster", menuName = "Spawnables/Booster", order = 1)]
public class SO_Booster : ScriptableObject
{
    [SerializeField] public Sprite boosterSprite;
    [SerializeField] public string boostType;
}