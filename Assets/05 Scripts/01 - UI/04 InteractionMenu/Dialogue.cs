using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dialogue : MonoBehaviour {

    public Canvas dialogueCanvas;

    public Text NameLeftUI;
    public Text NameRightUI;
    public Text DialogueTextUI;

    public int fadeInTime;
    public int fadeOutTime;

    public Image BackgroundAlpha;

    private CanvasGroup canvasGroup;

    // Use this for initialization
    void Start () {
    canvasGroup = dialogueCanvas.GetComponent<CanvasGroup>();
    canvasGroup.interactable = false;
    canvasGroup.blocksRaycasts = false;
    canvasGroup.alpha = 0;
    }

    public void UpdateDialogue(bool Allowbckgrnd, string NameLeft, string NameRight, string DialogueText) {
        AllowBackground(Allowbckgrnd);
        NameLeftUI.text = NameLeft;
        NameRightUI.text = NameRight;
        DialogueTextUI.text = DialogueText;


        StartCoroutine(DoFadeIn());

        //Fade in flash
        //canvasGroup.alpha = 1;
        //canvasGroup.interactable = true;
        //canvasGroup.blocksRaycasts = true;
    }

    public void CloseDialogue() {
        StartCoroutine(DoFadeOut());
    }

    IEnumerator DoFadeOut()
    {
        
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= fadeOutTime*Time.deltaTime;
            yield return null;
        }
       canvasGroup.interactable = false;
       canvasGroup.blocksRaycasts = false;
        yield return null;
    }

    IEnumerator DoFadeIn()
    {

        while (canvasGroup.alpha <1)
        {
            canvasGroup.alpha += fadeInTime * Time.deltaTime;
            yield return null;
        }
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        yield return null;
    }


    public void AllowBackground(bool Allowbckgrnd) {

        if (Allowbckgrnd == true) { BackgroundAlpha.color = new Color32(0, 0, 0, 150); }
        else { BackgroundAlpha.color = new Color32(0, 0, 0, 255); }

    }

}

