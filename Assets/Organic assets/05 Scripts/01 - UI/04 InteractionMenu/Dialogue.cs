using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dialogue : MonoBehaviour {

    private Canvas dialogueCanvas;

    public int fadeInTime;
    public int fadeOutTime;

    

    private Image BackGroundAlpha;
    private Image CharacterImage;
    private Image Center;
    private Image Panel;

    public bool isLoading;
    public bool isIntro;

    private CanvasGroup canvasGroup;

    // Use this for initialization
    void Awake () {

        canvasGroup = transform.GetComponent<CanvasGroup>();

        BackGroundAlpha = canvasGroup.GetComponentsInChildren<Image>()[0];
        CharacterImage = canvasGroup.GetComponentsInChildren<Image>()[1];
        Center = canvasGroup.GetComponentsInChildren<Image>()[2];
        Panel = canvasGroup.GetComponentsInChildren<Image>()[3];

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;

        isLoading = false;
        isIntro = true;

    }

    public void UpdateDialogue(byte AllowbckgrndInt255, string characterName, string DialogueText) {

        AllowBackground(AllowbckgrndInt255);

        // defining what is visible
        Panel.enabled = true;
        Center.enabled = false;

        if (characterName != " ") CharacterImage.enabled = true;
        else CharacterImage.enabled = false;


        Panel.GetComponentsInChildren<Text>()[1].text = characterName;
        Panel.GetComponentsInChildren<Text>()[0].text = DialogueText;
        Panel.GetComponentsInChildren<Text>()[0].alignment = TextAnchor.UpperLeft;

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

        BackGroundAlpha.color = new Color32(0, 0, 0, AllowbckgrndInt255); 

    }



    public void LoadingScreen(bool intro)
    {
        AllowBackground(200);
        Panel.GetComponentsInChildren<Text>()[1].text = " ";

        Center.enabled = true;
        CharacterImage.enabled = false;

        // defining what is visible
        if (intro == false)
        {
            isLoading = true;
            Panel.enabled = true;
            Panel.GetComponentsInChildren<Text>()[0].text = "Loading your city";
            Panel.GetComponentsInChildren<Text>()[0].alignment = TextAnchor.LowerCenter;
            StartCoroutine(DoFadeIn(2));
        }
        else {
            //Debug.Log("should be here once");
            Panel.enabled = false;
            Panel.GetComponentsInChildren<Text>()[0].text = " Click anywhere to proceed to the game";
            Panel.GetComponentsInChildren<Text>()[0].alignment = TextAnchor.LowerCenter;
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

    }


}

