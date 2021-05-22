using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;



public interface IRestAPI
{ 
    void UpdateRegion(int id, double snow, double ice, string comments);
}
public class RestManager : IRestAPI
{

    private string res;
    
    private SqliteConnection connection;

    private SqliteCommand cmd;

    private string path;
    

    
    private void Connect()
    {
        path = Application.streamingAssetsPath + "/database.bytes.db";

        connection = new SqliteConnection("URI=file:" + path);
        connection.Open();
        cmd = new SqliteCommand();
        cmd.Connection = connection;
    }
    
    
    
    
    public void UpdateRegion(int id, double snow, double ice, string comments)
    {
        try
        {
            Connect();
            var checkTime = DateTime.Now;
            cmd.CommandText = "UPDATE Region SET SnowLayer = " + snow + ", IceLayer = " + ice + ", CheckTime = " + checkTime + "WHERE Id = " + id;
            cmd.ExecuteNonQuery();
        }
        catch (System.Exception e)
        {
            connection.Close();
            throw e;
        }
    }
}
