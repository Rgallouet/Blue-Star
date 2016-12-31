using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Data;
using System.Text;
using Mono.Data.SqliteClient;

public class DataBaseManager : MonoBehaviour
{
    private string connection;
    private IDbConnection dbcon;
    private IDbCommand dbcmd;
    private IDataReader reader;
    private StringBuilder builder;

    // Use this for initialization
    void Start()
    {

    }

    public void OpenDB(string p)
    {

        // check if file exists in Application.persistentDataPath
        string filepath = Application.persistentDataPath + "/" + p;
        if (!File.Exists(filepath))
        {
            // if it doesn't ->
            // open StreamingAssets directory and load the db -> 
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + p);
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }

        //open db connection
        connection = "URI=file:" + filepath;

        dbcon = new SqliteConnection(connection);
        dbcon.Open();
    }

    public void CloseDB()
    {
        reader.Close(); // clean everything up
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }

    public IDataReader BasicQuery(string query)
    { // run a basic Sqlite query
        dbcmd = dbcon.CreateCommand(); // create empty command
        dbcmd.CommandText = query; // fill the command
        reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        return reader; // return the reader

    }


    public bool CreateTable(string name, string[] col, string[] colType)
    { // Create a table, name, column array, column type array
        string query;
        query = "CREATE TABLE " + name + "(" + col[0] + " " + colType[0];
        for (var i = 1; i < col.Length; i++)
        {
            query += ", " + col[i] + " " + colType[i];
        }
        query += ")";
        try
        {
            dbcmd = dbcon.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        }
        catch (Exception e)
        {

            Debug.Log(e);
            return false;
        }
        return true;
    }

    public int InsertIntoSingle(string tableName, string colName, string value)
    { // single insert
        string query;
        query = "INSERT INTO " + tableName + "(" + colName + ") " + "VALUES (" + value + ")";
        try
        {
            dbcmd = dbcon.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        }
        catch (Exception e)
        {

            Debug.Log(e);
            return 0;
        }
        return 1;
    }

    public int InsertIntoSpecific(string tableName, string[] col, string[] values)
    { // Specific insert with col and values
        string query;
        query = "INSERT INTO " + tableName + "(" + col[0];
        for (int i = 1; i < col.Length; i++)
        {
            query += ", " + col[i];
        }
        query += ") VALUES (" + values[0];
        for (int i = 1; i < col.Length; i++)
        {
            query += ", " + values[i];
        }
        query += ")";
        Debug.Log(query);
        try
        {
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();
        }
        catch (Exception e)
        {

            Debug.Log(e);
            return 0;
        }
        return 1;
    }

    public int InsertInto(string tableName, string[] values)
    { // basic Insert with just values
        string query;
        query = "INSERT INTO " + tableName + " VALUES (" + values[0];
        for (int i = 1; i < values.Length; i++)
        {
            query += ", " + values[i];
        }
        query += ")";
        try
        {
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();
        }
        catch (Exception e)
        {

            Debug.Log(e);
            return 0;
        }
        return 1;
    }

    public ArrayList SingleSelectWhere(string tableName, string itemToSelect, string wCol, string wPar, string wValue)
    { // Selects a single Item
        string query;
        query = "SELECT " + itemToSelect + " FROM " + tableName + " WHERE " + wCol + wPar + wValue;
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = query;
        reader = dbcmd.ExecuteReader();
        //string[,] readArray = new string[reader, reader.FieldCount];
        string[] row = new string[reader.FieldCount];
        ArrayList readArray = new ArrayList();
        while (reader.Read())
        {
            int j = 0;
            while (j < reader.FieldCount)
            {
                row[j] = reader.GetString(j);
                j++;
            }
            readArray.Add(row);
        }
        return readArray; // return matches
    }



    public ArrayList getArrayData(string sqlQuery, string p)
    {

        var ColArray = new ArrayList();
        var readArray = new ArrayList();

        try
        {
            OpenDB(p);
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();
        }
        catch (Exception e)
        {
            Debug.Log("Something Went Wrong..." + e);
            return readArray;
        }

        // reading data
        DataTable schemaTable = reader.GetSchemaTable();

        foreach (DataRow row in schemaTable.Rows)
        {
            ColArray.Add(row["ColumnName"]);
        }
        readArray.Add(ColArray);

        while (reader.Read())
        {
            var lineArray = new ArrayList();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                lineArray.Add(reader.GetValue(i)); // This reads the entries in a row
            }
            readArray.Add(lineArray); // This makes an array of all the rows
        }


        //Closing
        CloseDB();
        return (readArray);
    }

    
    // Update is called once per frame
    void Update()
    {

    }
}