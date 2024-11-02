using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelRequirements", menuName = "Level Requirements")]
public class LevelRequirementsSO : ScriptableObject
{
    public Dictionary<string, int> requiredPoints = new Dictionary<string, int>
    {
        { SceneNamesEnum.Level1.ToString(), 100 },
        { SceneNamesEnum.Level2.ToString(), 0 },
        { SceneNamesEnum.Level3.ToString(), 0 }
    };
}
