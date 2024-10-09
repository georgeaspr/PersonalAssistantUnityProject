using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmptyNotes: MonoBehaviour
{
    public TMP_InputField inputField;
    public string newText;

    public void ChangeText(string selectedText)
    {
        // Change the text of the input field when it is selected
        inputField.text = newText;
    }
}
