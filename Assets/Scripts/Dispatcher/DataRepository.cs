using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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


    public void UpdateReg(int id, double snow, double ice, System.DateTime checkTime, string comment, int snowFlow)
    {
        try
        {
            Connect();

            cmd.CommandText = "UPDATE Region SET SnowLayer = " + snow + ", IceLayer = " + ice + ", CheckTime = " + checkTime+ ", comment = " + comment + " , SnowFlow = " + snowFlow + " WHERE Id = " + id;
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
                result.Add(new Regions(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5)));
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

    public Regions SelectFromReg(int ID)
    {
        try
        {
            Connect();

            cmd.CommandText = "SELECT * FROM Region Where ID = " + ID;
            var reader = cmd.ExecuteReader();

            reader.Read();

            var result = new Regions(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));

            connection.Close();

            return result;
        }
        catch (System.Exception e)
        {
            connection.Close();
            throw e;
        }
    }

    public RegTechCount RegTechCountSelect(int regID, int type)
    {
        try
        {
            Connect();

            cmd.CommandText = "SELECT * FROM RegTechCount Where RegID = " + regID + " and Type = " + type;
            var reader = cmd.ExecuteReader();

            reader.Read();

            var result = new RegTechCount(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));

            connection.Close();

            return result;
        }
        catch (System.Exception e)
        {
            connection.Close();
            throw e;
        }
    }

    public List<Mechanism> SelectFreeMech()
    {
        try
        {
            Connect();

            cmd.CommandText = "SELECT * FROM Mechanism WHERE Status = " + 0 + " order by TotalTime";
            var reader = cmd.ExecuteReader();

            var resultList = new List<Mechanism>();


            while (reader.Read())
            {
                resultList.Add(new Mechanism(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5)));
            }

            connection.Close();

            return resultList;
            
        }
        
        catch (System.Exception e)
        {
            connection.Close();
            throw e;
        }
    }

    public List<Mechanism> SelectMech(int ID)
    {
        try
        {
            Connect();

            cmd.CommandText = "SELECT * FROM Mechanism WHERE ID = " + ID;
            var reader = cmd.ExecuteReader();

            var resultList = new List<Mechanism>();


            while (reader.Read())
            {
                resultList.Add(new Mechanism(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetInt32(5)));
            }

            connection.Close();

            return resultList;
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

            cmd.CommandText = "Insert Into TaskTech Values(" + techID + ", " + taskID + ")";
            cmd.ExecuteNonQuery();
        }
        catch(System.Exception e)
        {
            connection.Close();
            throw e;
        }
    }

    public List<TaskTech> SelectTaskMech(int techID, int taskID)
    {
        try
        {
            Connect();

            cmd.CommandText = "Select Task.id, Mechanism.id Where techID = " + techID + " and taskID = " + taskID;

            var reader = cmd.ExecuteReader();
            var resultList = new List<TaskTech>();


            while (reader.Read())
            {
                resultList.Add(new TaskTech(reader.GetInt32(0), reader.GetInt32(1)));
            }

            connection.Close();

            return resultList;
        }  
        catch (System.Exception e)
        {
            connection.Close();
            throw e;
        }
    }

    public List<Tasks> SelectTasks()
    {
        try
        {
            Connect();

            cmd.CommandText = "Select * From Task";

            var reader = cmd.ExecuteReader();
            var resultList = new List<Tasks>();


            while (reader.Read())
            {
                resultList.Add(new Tasks(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetInt32(5)));
            }

            connection.Close();

            return resultList;
        }
        catch (System.Exception e)
        {
            connection.Close();
            throw e;
        }
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
