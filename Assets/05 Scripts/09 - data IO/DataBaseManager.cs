using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Data;
using Mono.Data.Sqlite;

public class DataBaseManager : MonoBehaviour
{
    private string connection;
    private string filepath;
    private IDbConnection dbcon;
    private IDbCommand dbcmd;
    private IDataReader reader;

    // Use this for initialization
    void Awake()
    {

        // check if file exists in Application.persistentDataPath;
        filepath = Path.Combine(Application.persistentDataPath,"DataWarehouse.db");
        // filepath = Application.persistentDataPath + "/DataWarehouse.db";
        //filepath = "C:\\Users\\rgall\\AppData\\LocalLow\\TheGeekNextDoor\\Blue Stone\\DataWarehouse.db" ;

        if (!File.Exists(filepath))
        {
            // We have to create a data warehouse
            Debug.Log("Awaking - No database is available in the persistent data path, hence one will be created using the empty template in : " + filepath);

            // Get the template db from Resources
            TextAsset emptyDataWarehouse = Resources.Load<TextAsset>("DataWarehouse.db");

            // then save it in binazy to Application.persistentDataPath
            File.WriteAllBytes(filepath, emptyDataWarehouse.bytes);


        }
        else
        {
            // We have to create a data warehouse
            Debug.Log("Awaking - A database is saved in " + filepath);
        }

        //open db connection
        connection = "URI=file:" + filepath;

    }

    public void OpenDB()
    {

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


    public void ResetDB()
    {
        // CLosing anything open
        CloseDB();

        // deleting existing database
        File.Delete(filepath);


    }




    public int UpdateData(string tableName,string Where, string[] values)
    { 
        
        string query;
        query = "UPDATE " + tableName + " SET ";
        for (int i = 0; i < values.Length - 1; i++)
        {
            query += values[i] + ", " ;
        }
        query += values[values.Length - 1] + " where " + Where + ";";


        try
        {
            OpenDB();
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


    public int InsertData(string tableName, string[] values)
    {

        string query;
        query = "INSERT INTO " + tableName + " SELECT ";
        for (int i = 0; i < values.Length - 1; i++)
        {
            query += values[i] + ", ";
        }
        query += values[values.Length - 1] + ";";


        try
        {
            OpenDB();
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


    public int InsertOrUpdateData(string tableName, string PrimaryKey, int PrimaryKeyValue, string[] values)
    {

        string query;
        query = "INSERT INTO " + tableName + " SELECT "+ PrimaryKey + "="+ PrimaryKeyValue + ", ";
        for (int i = 0; i < values.Length - 1; i++)
        {
            query += values[i] + ", ";
        }
        query += values[values.Length - 1] + " ON CONFLICT("+ PrimaryKey+") DO UPDATE;";


        try
        {
            OpenDB();
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



    public ArrayList getArrayData(string sqlQuery)
    {

        var ColArray = new ArrayList();
        var readArray = new ArrayList();

        try
        {
            OpenDB();
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



    public void RunQuery(string sqlQuery)
    {

        try
        {
            OpenDB();
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();
        }
        catch (Exception e)
        {
            Debug.Log("Something Went Wrong..." + e);
        }

        //Closing
        CloseDB();
    }

}