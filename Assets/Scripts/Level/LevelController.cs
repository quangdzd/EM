using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController
{

    public GamePlaySpecs gamePlaySpecs;
    public LevelController(GamePlaySpecs gamePlaySpecs)
    {
        this.gamePlaySpecs = gamePlaySpecs;
    }
    public LevelSpecs levelSpecs;
    public List<Mask> Masks = new();
    public int currentMaskIndex = 0;

    public Mask CurrentMask =>
        currentMaskIndex < Masks.Count ? Masks[currentMaskIndex] : null;
    public bool HasMistake = false;
    public int currentTurn;

    public void SetLevel(LevelSpecs levelSpecs)
    {
        this.levelSpecs = levelSpecs;
        currentTurn = levelSpecs.turnCount;
        HasMistake = false;
        currentMaskIndex = 0;
        Masks.Clear();

        foreach (var type in levelSpecs.masks)
            Masks.Add(new Mask(gamePlaySpecs.GetMaskSpecs(type)));
    }

    public bool PlayerAction(SelectionType action, out string reaction, Action imageSkake = null , Action changeImage = null)
    {
        if (currentTurn <= 0)
        {
            reaction = "No turns left.";
            return false;
        }

        currentTurn--;

        bool success = CurrentMask.Interact(action, out reaction);


        if (!success)
        {
            HasMistake = true;
            return false;
        }
        imageSkake?.Invoke();



        if (CurrentMask.currentState == MaskState.Unmasked)
        {
            currentMaskIndex++;
            changeImage?.Invoke();
        }
        else
        {

        }

        return success;
    }
    public bool IsLevelComplete()
    {
        foreach (var mask in Masks)
            if (mask.currentState != MaskState.Unmasked)
                return false;
        return true;
    }

    public bool IsGameOver()
    {
        return currentTurn <= 0 && !IsLevelComplete();
    }
    public EndingType GetEndingType()
    {
        if (!HasMistake)
            return EndingType.True;

        return EndingType.Normal;
    }
    public void SetCurrentMaskImage(Image image)
    {
        if (image == null)
        {
            Debug.LogWarning("SetCurrentMaskImage: image is null");
            return;
        }

        if (CurrentMask == null)
        {
            Debug.LogWarning("SetCurrentMaskImage: CurrentMask is null");
            return;
        }

        CurrentMask.SetCurrentImage(image);
    }

}
