using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class PredefinedCharacters {

    public class Row
    {
        public int Id;
        public string CharactersName;
        public string CharactersDescription;
        public int HellCircleChoice;
        public int AllegianceChoice;
        public int GenusChoice;
        public int SpeciesChoice;
        public int JobChoice;
        public int ImpChoice;
        public int OriginChoice;
        public int TemperChoice;
        public int AstroChoice;
        public int AffinityChoice;

    }

    List<Row> rowList = new List<Row>();
    bool isLoaded = false;

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public List<Row> GetRowList()
    {
        return rowList;
    }

    public void Load(TextAsset csv)
    {
        rowList.Clear();
        string[][] grid = CsvParser2.Parse(csv.text);
        for (int i = 1; i < grid.Length; i++)
        {
            Row row = new Row();
            row.Id = int.Parse(grid[i][0]);
            row.CharactersName = grid[i][1];
            row.CharactersDescription = grid[i][2];
            row.HellCircleChoice = int.Parse(grid[i][3]);
            row.AllegianceChoice = int.Parse(grid[i][4]);
            row.GenusChoice = int.Parse(grid[i][5]);
            row.SpeciesChoice = int.Parse(grid[i][6]);
            row.JobChoice = int.Parse(grid[i][7]);
            row.ImpChoice = int.Parse(grid[i][8]);
            row.OriginChoice = int.Parse(grid[i][9]);
            row.TemperChoice = int.Parse(grid[i][10]);
            row.AstroChoice = int.Parse(grid[i][11]);
            row.AffinityChoice = int.Parse(grid[i][12]);

            rowList.Add(row);
        }
        isLoaded = true;
    }

    public int NumRows()
    {
        return rowList.Count;
    }

    public Row GetAt(int i)
    {
        if (rowList.Count <= i)
            return null;
        return rowList[i];
    }

    public Row Find_Id(int find)
    {
        return rowList.Find(x => x.Id == find);
    }
    public List<Row> FindAll_Id(int find)
    {
        return rowList.FindAll(x => x.Id == find);
    }
    public Row Find_CharactersName(string find)
    {
        return rowList.Find(x => x.CharactersName == find);
    }
    public List<Row> FindAll_CharactersName(string find)
    {
        return rowList.FindAll(x => x.CharactersName == find);
    }
    public Row Find_CharactersDescription(string find)
    {
        return rowList.Find(x => x.CharactersDescription == find);
    }
    public List<Row> FindAll_CharactersDescription(string find)
    {
        return rowList.FindAll(x => x.CharactersDescription == find);
    }
    public Row Find_HellCircleChoice(int find)
    {
        return rowList.Find(x => x.HellCircleChoice == find);
    }
    public List<Row> FindAll_HellCircleChoice(int find)
    {
        return rowList.FindAll(x => x.HellCircleChoice == find);
    }
    public Row Find_AllegianceChoice(int find)
    {
        return rowList.Find(x => x.AllegianceChoice == find);
    }
    public List<Row> FindAll_AllegianceChoice(int find)
    {
        return rowList.FindAll(x => x.AllegianceChoice == find);
    }
    public Row Find_GenusChoice(int find)
    {
        return rowList.Find(x => x.GenusChoice == find);
    }
    public List<Row> FindAll_GenusChoice(int find)
    {
        return rowList.FindAll(x => x.GenusChoice == find);
    }
    public Row Find_SpeciesChoice(int find)
    {
        return rowList.Find(x => x.SpeciesChoice == find);
    }
    public List<Row> FindAll_SpeciesChoice(int find)
    {
        return rowList.FindAll(x => x.SpeciesChoice == find);
    }
    public Row Find_JobChoice(int find)
    {
        return rowList.Find(x => x.JobChoice == find);
    }
    public List<Row> FindAll_JobChoice(int find)
    {
        return rowList.FindAll(x => x.JobChoice == find);
    }
    public Row Find_ImpChoice(int find)
    {
        return rowList.Find(x => x.ImpChoice == find);
    }
    public List<Row> FindAll_ImpChoice(int find)
    {
        return rowList.FindAll(x => x.ImpChoice == find);
    }
    public Row Find_OriginChoice(int find)
    {
        return rowList.Find(x => x.OriginChoice == find);
    }
    public List<Row> FindAll_OriginChoice(int find)
    {
        return rowList.FindAll(x => x.OriginChoice == find);
    }
    public Row Find_TemperChoice(int find)
    {
        return rowList.Find(x => x.TemperChoice == find);
    }
    public List<Row> FindAll_TemperChoice(int find)
    {
        return rowList.FindAll(x => x.TemperChoice == find);
    }
    public Row Find_AstroChoice(int find)
    {
        return rowList.Find(x => x.AstroChoice == find);
    }
    public List<Row> FindAll_AstroChoice(int find)
    {
        return rowList.FindAll(x => x.AstroChoice == find);
    }
    public Row Find_AffinityChoice(int find)
    {
        return rowList.Find(x => x.AffinityChoice == find);
    }
    public List<Row> FindAll_AffinityChoice(int find)
    {
        return rowList.FindAll(x => x.AffinityChoice == find);
    }





}