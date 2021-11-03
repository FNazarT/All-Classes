using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextPanel : MonoBehaviour
{
    [SerializeField] private Text panelText = default;
    private string UIText = "101 Training / Diplomado Unity / Clase UI";
    private string message;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PrintMessage()
    {
        StartCoroutine(PrintLetterByLetter());
    }

    IEnumerator PrintLetterByLetter()
    {
        string startTag = "<color=blue>";
        string endTag = "</color>";

        foreach (char letter in UIText)
        {
            message += letter;
            panelText.text = startTag + message + endTag;
            yield return new WaitForSeconds(0.1f);
        }

        anim.Play("PanelDown");
    }
}
