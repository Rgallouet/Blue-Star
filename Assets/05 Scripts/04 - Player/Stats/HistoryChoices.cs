using UnityEngine;
using System.Collections;

public class HistoryChoices{

    public string HellCircleChoice;
    public string AllegianceChoice;
    public string SocialChoice;
    public string JobChoice;
    public string ImpChoice;
    public string OriginChoice;
    public string TemperChoice;
    public string AstroChoice;
    public string AffinityChoice;

    public int LeadershipCost;



    public void CreateHistoryChoicesFromInt(int[] choices)
    {

        HellCircleChoice = "01_0" + choices[0];
        AllegianceChoice = "02_0" + choices[1];
        SocialChoice = "03_0" + choices[2];
        JobChoice = "04_0" + choices[3];
        ImpChoice = "05_0" + choices[4];
        OriginChoice = "06_0" + choices[5];
        TemperChoice = "07_0" + choices[6];
        AstroChoice = "08_0" + choices[7];
        AffinityChoice = "09_0" + choices[8];
    }

    public void CreateHistoryChoicesFromString(string[] choices)
    {

        HellCircleChoice = choices[0];
        AllegianceChoice = choices[1];
        SocialChoice = choices[2];
        JobChoice = choices[3];
        ImpChoice = choices[4];
        OriginChoice = choices[5];
        TemperChoice = choices[6];
        AstroChoice = choices[7];
        AffinityChoice = choices[8];
    }

    public int[] GetIntListFromStoredChoices()
    {
        int[] HistoryChoicesInt = new int[9];

        HistoryChoicesInt[0] = int.Parse(HellCircleChoice.Substring(3,2));
        HistoryChoicesInt[1] = int.Parse(AllegianceChoice.Substring(3, 2));
        HistoryChoicesInt[2] = int.Parse(SocialChoice.Substring(3, 2));
        HistoryChoicesInt[3] = int.Parse(JobChoice.Substring(3, 2));
        HistoryChoicesInt[4] = int.Parse(ImpChoice.Substring(3, 2));
        HistoryChoicesInt[5] = int.Parse(OriginChoice.Substring(3, 2));
        HistoryChoicesInt[6] = int.Parse(TemperChoice.Substring(3, 2));
        HistoryChoicesInt[7] = int.Parse(AstroChoice.Substring(3, 2));
        HistoryChoicesInt[8] = int.Parse(AffinityChoice.Substring(3, 2));

        return HistoryChoicesInt;
    }


}
