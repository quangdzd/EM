using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public string Lines{get;set;}
    public float textSpeed;

    private int index;

    public void SetDialogue(string text , Action callback = null)
    {
        index = 0;
        textBox.text = string.Empty;
        Lines = text;
        StartCoroutine(TypeLine(callback));

    }

    IEnumerator TypeLine(Action callball = null)
    {
        foreach ( char c in Lines.ToCharArray())
        {
            textBox.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(textSpeed);

        callball?.Invoke();
    }



}
