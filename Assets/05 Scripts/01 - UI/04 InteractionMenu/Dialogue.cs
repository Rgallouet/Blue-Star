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

    public Image CharacterRight;
    public Image CharacterLeft;
    public Image Center;
    public Image Panel;

    public bool isLoading;
    public bool isIntro;

    private CanvasGroup canvasGroup;

    // Use this for initialization
    void Start () {

        canvasGroup = dialogueCanvas.GetComponent<CanvasGroup>();
        CharacterRight = canvasGroup.GetComponentsInChildren<Image>()[1];
        CharacterLeft = canvasGroup.GetComponentsInChildren<Image>()[2];
        Center = canvasGroup.GetComponentsInChildren<Image>()[3];
        Panel = canvasGroup.GetComponentsInChildren<Image>()[4];

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;

        isLoading = false;
        isIntro = true;

    }

    public void UpdateDialogue(byte AllowbckgrndInt255, string NameLeft, string NameRight, string DialogueText) {

        AllowBackground(AllowbckgrndInt255);

        // defining what is visible
        Panel.enabled = true;
        Center.enabled = false;

        if (NameLeft != " ") CharacterLeft.enabled = true;
        else CharacterLeft.enabled = false;

        if (NameRight != " ") CharacterRight.enabled = true;
        else CharacterRight.enabled = false;

        NameLeftUI.text = NameLeft;
        NameRightUI.text = NameRight;
        DialogueTextUI.text = DialogueText;
        DialogueTextUI.alignment = TextAnchor.UpperLeft;

        StartCoroutine(DoFadeIn(2));

        //Fade in flash
        //canvasGroup.alpha = 1;
        //canvasGroup.interactable = true;
        //canvasGroup.blocksRaycasts = true;
    }

    public void CloseDialogue() {
        
        isIntro = false;

        if (isLoading == false)
        {
            StartCoroutine(DoFadeOut(2));
        }
        

    }

    IEnumerator DoFadeOut(float speedFactor)
    {
        
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= fadeOutTime * speedFactor * Time.deltaTime;
            yield return null;
        }
       canvasGroup.interactable = false;
       canvasGroup.blocksRaycasts = false;
        yield return null;
    }

    IEnumerator DoFadeIn(float speedFactor)
    {

        while (canvasGroup.alpha <1)
        {
            canvasGroup.alpha += fadeInTime* speedFactor * Time.deltaTime;
            yield return null;
        }
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        yield return null;
    }


    public void AllowBackground(byte AllowbckgrndInt255) {

        BackgroundAlpha.color = new Color32(0, 0, 0, AllowbckgrndInt255); 

    }



    public void LoadingScreen(bool intro)
    {
        AllowBackground(200);
        NameLeftUI.text = " ";
        NameRightUI.text = " ";

        Center.enabled = true;
        CharacterLeft.enabled = false;
        CharacterRight.enabled = false;

        // defining what is visible
        if (intro == false)
        {
            isLoading = true;
            Panel.enabled = true;
            DialogueTextUI.text = "Loading your city";
            DialogueTextUI.alignment = TextAnchor.LowerCenter;
            StartCoroutine(DoFadeIn(2));
        }
        else {
            Panel.enabled = false;
            DialogueTextUI.text = " Click anywhere to proceed to the game";
            DialogueTextUI.alignment = TextAnchor.LowerCenter;
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

    }


}

