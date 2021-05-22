using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Mechanism
{
    int ID;
    int type;
    int status;
    double longit;
    double lat;
    int totalTime;

    public Mechanism(int ID, int type, int status, double longit, double lat, int totalTime)
    {
        this.ID = ID;
        this.type = type;
        this.status = status;
        this.longit = longit;
        this.lat = lat;
        this.totalTime = totalTime;
    }
}

