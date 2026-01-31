using System;
using DG.Tweening;
using UnityEngine;

public class GamePlay : Singleton<GamePlay>
{
    public GamePlaySpecs gamePlaySpecs;
    public DialogueManager dialogueManager;
    public MaskDisplay maskDisplay;
    public LevelDisplay levelDisplay;
    public Selection[] selections;
    private LevelController levelController;
    private int currentLevel;
    protected override void Awake()
    {
        base.Awake();
        levelController = new LevelController(gamePlaySpecs);
        currentLevel = 1;
    }

    private void Start()
    {
        EnterLevel(currentLevel);
    }
    public void Interact(SelectionType selectionType)
    {
        if (levelController == null)
            return;


        bool success = levelController.PlayerAction(
        selectionType,
        out string reaction,
        () => levelController.SetCurrentMaskImage(maskDisplay.image)
        );
        levelDisplay.TurnCount.text = levelController.currentTurn.ToString();
        HiddenSelections();
        dialogueManager.SetDialogue(reaction);

        if (success)
        {
            maskDisplay.Shake(() =>
            {
                if (levelController.IsLevelComplete())
                {
                    Debug.Log("LEVEL COMPLETE");
                    currentLevel += 1;
                    EnterLevel(currentLevel);
                }
                else if (levelController.IsGameOver())
                {
                    Debug.Log("GAME OVER");
                }

            });
        }


    }
    public void StartLevel(LevelSpecs levelSpecs)
    {
        levelController.SetLevel(levelSpecs);
    }

    public void EnterLevel(int index)
    {
        StartLevel(gamePlaySpecs.LevelSpecs[index - 1]);
        levelDisplay.level.text = index.ToString();
        levelDisplay.TurnCount.text = levelController.currentTurn.ToString();
        if(index != 1)FadeInImage(() =>
        {
            levelController.SetCurrentMaskImage(maskDisplay.image);
            FadeOutImage();
        });
        else
        {
            levelController.SetCurrentMaskImage(maskDisplay.image);
        }

    }

    public void HiddenSelections()
    {
        foreach (var sl in selections)
        {
            sl.Hidden(sl.Expose);
        }
    }

    public void FadeInImage(Action callBack)
    {
        maskDisplay.image.DOFade(0f, 1f)
            .SetEase(Ease.OutQuad)
            .SetLink(gameObject).OnComplete(() => callBack?.Invoke());
    }

    public void FadeOutImage()
    {
        maskDisplay.image.DOFade(1f, 1f)
            .SetEase(Ease.OutQuad)
            .SetLink(gameObject);
    }





}
