using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Data;
using System.IO;

using Mono.Data.Sqlite;
using UnityEngine.UI;


public class DataRepository
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


    public void GetProject(int id)
    {
        Connect();

        cmd.CommandText = "SELECT * FROM Projects WHERE Id = " + id;

        var reader = cmd.ExecuteReader();
        reader.Read();

        //var result = new Project(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));


        reader.Close();
        connection.Close();

        return;
    }

    public void GetProjectMembers(int projectId)
    {
        try
        {
            Connect();
            cmd.CommandText = "SELECT * FROM Members INNER JOIN Accounts ON Members.AccountId = Accounts.Id WHERE ProjectId = " + projectId;

            var reader = cmd.ExecuteReader();
           // var resultList = new List<ProjectMember>();


            while (reader.Read())
            {
               // resultList.Add(new ProjectMember(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(8) , reader.GetString(9)));
            }


            connection.Close();
           // return resultList;

        }
        catch (System.Exception e)
        {
            connection.Close();
            throw e;
        }


    }
    
}
