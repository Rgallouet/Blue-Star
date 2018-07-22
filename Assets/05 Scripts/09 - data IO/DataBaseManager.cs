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
    private string filepath;
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
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {

            // check if file exists in Application.persistentDataPath
            filepath = Application.persistentDataPath + "/" + p;

            if (!File.Exists(filepath))
            {
                // if it doesn't ->
                // open StreamingAssets directory and load the db -> 
                WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + p);
                while (!loadDB.isDone) { }

                // then save to Application.persistentDataPath
                File.WriteAllBytes(filepath, loadDB.bytes);
            }

        }
       else {

            filepath = Application.streamingAssetsPath + "/" + p;
            }

        /* testing the path
        Debug.Log("path is " + filepath);
        */


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

    public int UpdateData(string tableName,string Where, string[] values, string p = "BlueStarDataWarehouse.db")
    { 
        
        string query;
        query = "UPDATE " + tableName + " SET ";
        for (int i = 0; i < values.Length - 1; i++)
        {
            query += values[i] + ", " ;
        }
        query += values[values.Length - 1] + " where " + Where + ";";

        Debug.Log("Query: " + query);

        try
        {
            OpenDB(p);
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
    


    public ArrayList getArrayData(string sqlQuery, string p = "BlueStarDataWarehouse.db")
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

}