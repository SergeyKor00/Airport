using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Tasks
{
    int ID;
    int regID;
    int status;
    double lat;
    double longit;
    int type;

    public Tasks(int ID, int regID, int status, double lat, double longit, int type)
    {
        this.ID = ID;
        this.regID = regID;
        this.status = status;
        this.lat = lat;
        this.longit = longit;
        this.type = type;
    }
}

