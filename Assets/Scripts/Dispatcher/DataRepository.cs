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


    public void UpdateReg(int id, double snow, double ice, System.DateTime checkTime)
    {
        try
        {
            Connect();

            cmd.CommandText = "UPDATE Region SET SnowLayer = " + snow + ", IceLayer = " + ice + ", CheckTime = " + checkTime + "WHERE Id = " + id;
            cmd.ExecuteNonQuery();
            
            connection.Close();
        }
        catch (System.Exception e)
        {
            connection.Close();
            throw e;
        }
    }

    public List<Regions> SelectFromReg()
    {
        try
        {
            Connect();

            cmd.CommandText = "SELECT * FROM Region";
            var reader = cmd.ExecuteReader();

            var result = new List<Regions>();

            while (reader.Read())
            {
                //result.Add(new Regions(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDateTime(3)));
            }

            connection.Close();

            return result;
        }
        catch (System.Exception e)
        {
            connection.Close();
            throw e;
        }
    }

    public void SelectFreeMech()
    {
        try
        {
            Connect();

            cmd.CommandText = "SELECT * FROM Mechanism WHERE Status = " + 0;
            var reader = cmd.ExecuteReader();
            connection.Close();
        }
        
        catch (System.Exception e)
        {
            connection.Close();
            throw e;
        }
    }

    public void InsertIntoTask(int reg_Id, int status, int type, double lat, double longit)
    {
        try
        {
            Connect();
            cmd.CommandText = "INSERT INTO Tasks VALUES(" + status + "," + type + "," + lat + "," + longit + ")";
            cmd.ExecuteNonQuery();
        }
        catch (System.Exception e)
        {
            connection.Close();
            throw e;
        }
    }

    public void InsertIntoTaskTech(int techID, int taskID)
    {
        try
        {
            Connect();

            cmd.CommandText = "Insert Into TaskTech values(" + techID + ", " + taskID + ")";
            cmd.ExecuteNonQuery();
        }
        catch(System.Exception e)
        {
            connection.Close();
            throw e;
        }
    }

    public void SelectTaskMech(int techID, int taskID)
    {
        Connect();

        cmd.CommandText =
            "Select Task.id, Task.status, Task.Type, Task.lat, Task.long,  Mechanism.id, Mechanism.Status, Mechanism.Type, Mechanism.lat, Mechanism.long, Mechanism.WorkTime From Task Join TaskTech on Task.id = taskID Join Mechanism on ";
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
