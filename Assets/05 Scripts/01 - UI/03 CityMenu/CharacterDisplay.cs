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


    public void UpdateCharacterDisplay(HistoryChoices historyChoices, bool PrintNames) {


        if (PrintNames == true)
        {

            if (historyChoices.HellCircleChoice != 0)   HistoryChoiceText[0].text = (string)((ArrayList)RefHellCircles[historyChoices.HellCircleChoice])[2];    else HistoryChoiceText[0].text = "";
            if (historyChoices.AllegianceChoice != 0)   HistoryChoiceText[1].text = (string)((ArrayList)RefAllegiance[historyChoices.AllegianceChoice])[2];     else HistoryChoiceText[1].text = "";
            if (historyChoices.GenusChoice != 0)        HistoryChoiceText[2].text = (string)((ArrayList)RefGenus[historyChoices.GenusChoice])[2];               else HistoryChoiceText[2].text = "";
            if (historyChoices.SpeciesChoice != 0)      HistoryChoiceText[3].text = (string)((ArrayList)RefSpecies[historyChoices.SpeciesChoice])[2];           else HistoryChoiceText[3].text = "";
            if (historyChoices.JobChoice != 0)          HistoryChoiceText[4].text = (string)((ArrayList)RefClass[historyChoices.JobChoice])[2];                 else HistoryChoiceText[4].text = "";
            if (historyChoices.ImpChoice != 0)          HistoryChoiceText[5].text = (string)((ArrayList)RefImp[historyChoices.ImpChoice])[2];                   else HistoryChoiceText[5].text = "";
            if (historyChoices.OriginChoice != 0)       HistoryChoiceText[6].text = (string)((ArrayList)RefOrigin[historyChoices.OriginChoice])[2];             else HistoryChoiceText[6].text = "";
            if (historyChoices.TemperChoice != 0)       HistoryChoiceText[7].text = (string)((ArrayList)RefTemper[historyChoices.TemperChoice])[2];             else HistoryChoiceText[7].text = "";
            if (historyChoices.AstroChoice != 0)        HistoryChoiceText[8].text = (string)((ArrayList)RefAstro[historyChoices.AstroChoice])[2];               else HistoryChoiceText[8].text = "";
            if (historyChoices.AffinityChoice != 0)     HistoryChoiceText[9].text = (string)((ArrayList)RefAffinity[historyChoices.AffinityChoice])[2];         else HistoryChoiceText[9].text = "";


        }
        else { for (int i = 0; i < 10; i++) { HistoryChoiceText[i].text = ""; } }


        HistoryChoiceImage[0].sprite = RightArmSprites[System.Convert.ToInt32(((ArrayList)RefHellCircles[historyChoices.HellCircleChoice])[26])];
        HistoryChoiceImage[1].sprite = LeftImpSprites[System.Convert.ToInt32(((ArrayList)RefAllegiance[historyChoices.AllegianceChoice])[26])];
        HistoryChoiceImage[2].sprite = HeadSprites[System.Convert.ToInt32(((ArrayList)RefSpecies[historyChoices.SpeciesChoice])[26])];
        HistoryChoiceImage[3].sprite = LeftArmSprites[System.Convert.ToInt32(((ArrayList)RefClass[historyChoices.JobChoice])[26])];
        HistoryChoiceImage[4].sprite = RightImpSprites[System.Convert.ToInt32(((ArrayList)RefImp[historyChoices.ImpChoice])[26])];
        HistoryChoiceImage[5].sprite = TorsoSprites[System.Convert.ToInt32(((ArrayList)RefOrigin[historyChoices.OriginChoice])[26])];
        HistoryChoiceImage[6].sprite = LegsSprites[System.Convert.ToInt32(((ArrayList)RefTemper[historyChoices.TemperChoice])[26])];
        HistoryChoiceImage[7].sprite = RightFootSprites[System.Convert.ToInt32(((ArrayList)RefAstro[historyChoices.AstroChoice])[26])];
        HistoryChoiceImage[8].sprite = LeftFootSprites[System.Convert.ToInt32(((ArrayList)RefAffinity[historyChoices.AffinityChoice])[26])];


    }


}
