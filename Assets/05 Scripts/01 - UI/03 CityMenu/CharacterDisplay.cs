using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterDisplay : MonoBehaviour {

    public DataBaseManager dataBaseManager;

    private ArrayList RefHellCircles = new ArrayList();
    private ArrayList RefAllegiance = new ArrayList();
    private ArrayList RefGenus = new ArrayList();
    private ArrayList RefSpecies = new ArrayList();
    private ArrayList RefClass = new ArrayList();
    private ArrayList RefImp = new ArrayList();
    private ArrayList RefOrigin = new ArrayList();
    private ArrayList RefTemper = new ArrayList();
    private ArrayList RefAstro = new ArrayList();
    private ArrayList RefAffinity = new ArrayList();

    private Image[] HistoryChoiceImage = new Image[9];
    private Text[] HistoryChoiceText = new Text[10];

    // Spirtes for displaying choices
    public Sprite[] RightArmSprites = new Sprite[10];
    public Sprite[] LeftImpSprites = new Sprite[10];
    public Sprite[] HeadSprites = new Sprite[19];
    public Sprite[] LeftArmSprites = new Sprite[10];
    public Sprite[] RightImpSprites = new Sprite[10];
    public Sprite[] TorsoSprites = new Sprite[10];
    public Sprite[] LegsSprites = new Sprite[10];
    public Sprite[] RightFootSprites = new Sprite[10];
    public Sprite[] LeftFootSprites = new Sprite[10];



    // Use this for initialization
    void Start () {

        for (int i = 0; i < 9; i++)  { HistoryChoiceImage[i] = GetComponentsInChildren<Image>()[i + 1]; }
        for (int i = 0; i < 10; i++) { HistoryChoiceText[i] = GetComponentsInChildren<Text>()[i]; }

        // Récupérer les référentiels
        RefHellCircles = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='HellCircles' order by Id asc");
        RefAllegiance = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Allegiance' order by Id asc");
        RefGenus = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Genus' order by Id asc");
        RefSpecies = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Species' order by Id asc");
        RefClass = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Class' order by Id asc");
        RefImp = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Imp' order by Id asc");
        RefOrigin = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Origin' order by Id asc");
        RefTemper = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Temper' order by Id asc");
        RefAstro = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Astro' order by Id asc");
        RefAffinity = dataBaseManager.getArrayData("select * from REF_CustomCharacters where ChoiceStage='Affinity' order by Id asc");

        
    }


    public void UpdateCharacterDisplay(int[] historyChoices, bool PrintNames) {


        if (PrintNames == true)
        {

            if (historyChoices[0] != 0)   HistoryChoiceText[0].text = (string)((ArrayList)RefHellCircles[historyChoices[0]])[2];  else HistoryChoiceText[0].text = "";
            if (historyChoices[1] != 0)   HistoryChoiceText[1].text = (string)((ArrayList)RefAllegiance[historyChoices[1]])[2];   else HistoryChoiceText[1].text = "";
            if (historyChoices[2] != 0)   HistoryChoiceText[2].text = (string)((ArrayList)RefGenus[historyChoices[2]])[2];        else HistoryChoiceText[2].text = "";
            if (historyChoices[3] != 0)   HistoryChoiceText[3].text = (string)((ArrayList)RefSpecies[historyChoices[3]])[2];      else HistoryChoiceText[3].text = "";
            if (historyChoices[4] != 0)   HistoryChoiceText[4].text = (string)((ArrayList)RefClass[historyChoices[4]])[2];        else HistoryChoiceText[4].text = "";
            if (historyChoices[5] != 0)   HistoryChoiceText[5].text = (string)((ArrayList)RefImp[historyChoices[5]])[2];          else HistoryChoiceText[5].text = "";
            if (historyChoices[6] != 0)   HistoryChoiceText[6].text = (string)((ArrayList)RefOrigin[historyChoices[6]])[2];       else HistoryChoiceText[6].text = "";
            if (historyChoices[7] != 0)   HistoryChoiceText[7].text = (string)((ArrayList)RefTemper[historyChoices[7]])[2];       else HistoryChoiceText[7].text = "";
            if (historyChoices[8] != 0)   HistoryChoiceText[8].text = (string)((ArrayList)RefAstro[historyChoices[8]])[2];        else HistoryChoiceText[8].text = "";
            if (historyChoices[9] != 0)   HistoryChoiceText[9].text = (string)((ArrayList)RefAffinity[historyChoices[9]])[2];     else HistoryChoiceText[9].text = "";


        }
        else { for (int i = 0; i < 10; i++) { HistoryChoiceText[i].text = ""; } }


        HistoryChoiceImage[0].sprite = RightArmSprites[(int)((ArrayList)RefHellCircles[historyChoices[0]])[26]];
        HistoryChoiceImage[1].sprite = LeftImpSprites[(int)((ArrayList)RefAllegiance[historyChoices[1]])[26]];
        HistoryChoiceImage[2].sprite = HeadSprites[(int)((ArrayList)RefSpecies[historyChoices[2]])[26]];
        HistoryChoiceImage[3].sprite = LeftArmSprites[(int)((ArrayList)RefClass[historyChoices[3]])[26]];
        HistoryChoiceImage[4].sprite = RightImpSprites[(int)((ArrayList)RefImp[historyChoices[4]])[26]];
        HistoryChoiceImage[5].sprite = TorsoSprites[(int)((ArrayList)RefOrigin[historyChoices[5]])[26]];
        HistoryChoiceImage[6].sprite = LegsSprites[(int)((ArrayList)RefTemper[historyChoices[6]])[26]];
        HistoryChoiceImage[7].sprite = RightFootSprites[(int)((ArrayList)RefAstro[historyChoices[7]])[26]];
        HistoryChoiceImage[8].sprite = LeftFootSprites[(int)((ArrayList)RefAffinity[historyChoices[8]])[26]];


    }


}
