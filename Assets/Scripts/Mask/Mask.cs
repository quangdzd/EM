using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Mask
{
    public MaskSpecs maskSpecs;
    public MaskState currentState;
    private int currentIndex;

    public Mask(MaskSpecs maskSpecs)
    {
        this.maskSpecs = maskSpecs;
        currentState = MaskState.Hidden;
        currentIndex = 0;
    }

    public bool Interact(SelectionType action, out string reaction)
    {
        currentState = MaskState.Reacting;
        if (action == SelectionType.Observe)
        {
            reaction = GetObserveText(maskSpecs.maskType);
            return true;
        }

        if (action == maskSpecs.correctSequence[currentIndex])
        {
            currentIndex++;
            reaction = "The mask trembles slightly...";

            if (currentIndex >= maskSpecs.correctSequence.Length)
            {
                currentState = MaskState.Unmasked;
                reaction = "The mask breaks open.";
            }
            Debug.Log("" + currentIndex);
            return true;
        }

        // Sai
        reaction = GetWrongReaction();
        currentIndex = 0; // reset sequence
        return false;
    }
    private string GetObserveText(MaskType maskType)
    {
        return maskSpecs.observeDialog;
    }
    private string GetWrongReaction()
    {
        return maskSpecs.wrongDialog;
    }

    public void SetCurrentImage(Image image)
    {
        if (currentIndex < this.maskSpecs.sprites.Length)
        {
            image.sprite = this.maskSpecs.sprites[currentIndex];
        }
    }
}
