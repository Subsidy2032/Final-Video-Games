using UnityEngine;

[CreateAssetMenu(fileName = "New Ball", menuName = "Spawnables/Ball", order = 1)]
public class SO_Ball : ScriptableObject
{
    // Added field for decresing points
    [SerializeField] public Sprite ballSprite;
    [SerializeField] public int addPoints;
    [SerializeField] public int removePoints;
}
