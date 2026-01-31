using UnityEngine;
[CreateAssetMenu(fileName = "MaskSpecs", menuName = "CustomScriptableObject/MaskSpecs", order = 0)]
public class MaskSpecs : ScriptableObject
{
    public Sprite[] sprites;
    public MaskType maskType;
    public SelectionType[] correctSequence;
    public string[] normalDialog;
    public string observeDialog;
    public string wrongDialog;
}
