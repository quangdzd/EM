using UnityEngine;
using UnityEngine.UI;

public class EnterLevel : MonoBehaviour
{
    private Button button;
    public LevelSpecs levelSpecs;
    private void Awake()
    {
        button = GetComponent<Button>();
    }

    void Start()
    {
        button.onClick.AddListener(StartLevel);
    }
    public void StartLevel()
    {
        GamePlay.Instance.StartLevel(levelSpecs);
    }
}
