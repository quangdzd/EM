using UnityEngine;
[CreateAssetMenu(fileName = "Level", menuName = "CustomScriptableObject/LevelSpecs", order = 0)]

public class LevelSpecs : ScriptableObject
{
    public int turnCount;
    public MaskType[] masks;
}
