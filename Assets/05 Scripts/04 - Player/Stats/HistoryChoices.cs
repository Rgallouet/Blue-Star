using UnityEngine;
using System.Collections;

public class HistoryChoices{

    public string HellCircleChoice;
    public string AllegianceChoice;
    public string GenusChoice;
    public string SpeciesChoice;
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
        GenusChoice = "03_0" + choices[2] + "g";
        if (choices[3] < 10) SpeciesChoice = "03_0" + choices[3] + "s";
        else SpeciesChoice = "03_" + choices[3] + "s";
        JobChoice = "04_0" + choices[4];
        ImpChoice = "05_0" + choices[5];
        OriginChoice = "06_0" + choices[6];
        TemperChoice = "07_0" + choices[7];
        AstroChoice = "08_0" + choices[8];
        AffinityChoice = "09_0" + choices[9];
    }

    public void CreateHistoryChoicesFromString(string[] choices)
    {

        HellCircleChoice = choices[0];
        AllegianceChoice = choices[1];
        GenusChoice = choices[2];
        SpeciesChoice = choices[3];
        JobChoice = choices[4];
        ImpChoice = choices[5];
        OriginChoice = choices[6];
        TemperChoice = choices[7];
        AstroChoice = choices[8];
        AffinityChoice = choices[9];
    }

    public int[] GetIntListFromStoredChoices()
    {
        int[] HistoryChoicesInt = new int[10];

        HistoryChoicesInt[0] = int.Parse(HellCircleChoice.Substring(3,2));
        HistoryChoicesInt[1] = int.Parse(AllegianceChoice.Substring(3, 2));
        HistoryChoicesInt[2] = int.Parse(GenusChoice.Substring(3, 2));
        HistoryChoicesInt[3] = int.Parse(SpeciesChoice.Substring(3, 2));
        HistoryChoicesInt[4] = int.Parse(JobChoice.Substring(3, 2));
        HistoryChoicesInt[5] = int.Parse(ImpChoice.Substring(3, 2));
        HistoryChoicesInt[6] = int.Parse(OriginChoice.Substring(3, 2));
        HistoryChoicesInt[7] = int.Parse(TemperChoice.Substring(3, 2));
        HistoryChoicesInt[8] = int.Parse(AstroChoice.Substring(3, 2));
        HistoryChoicesInt[9] = int.Parse(AffinityChoice.Substring(3, 2));

        return HistoryChoicesInt;
    }


}
