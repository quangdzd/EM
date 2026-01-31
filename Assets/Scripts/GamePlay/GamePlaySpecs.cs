using UnityEngine;

[CreateAssetMenu(fileName = "GamePlaySpecs", menuName = "CustomScriptableObject/GamePlaySpecs", order = 0)]
public class GamePlaySpecs : ScriptableObject
{
    public LevelSpecs[] LevelSpecs;
    public MaskSpecs FearMaskSpecs;
    public MaskSpecs AngryMaskSpecs;
    public MaskSpecs PrideMaskSpecs;

    public MaskSpecs GetMaskSpecs(MaskType maskType)
    {
        switch (maskType)
        {
            case MaskType.Fear:
                return FearMaskSpecs;
            case MaskType.Angry:
                return AngryMaskSpecs;
            case MaskType.Pride:
                return PrideMaskSpecs;
            default:
                return null;
        }
    }
}
