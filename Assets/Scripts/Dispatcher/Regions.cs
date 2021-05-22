using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Regions
{
    public int ID;
    public double snow;
    public double ice;
    public string checkTime;
    public string comment;
    public int snowFlow;

    public Regions(int ID, double snow, double ice, string checkTime, string comment, int snowFlow)
    {
        this.ID = ID;
        this.snow = snow;
        this.ice = ice;
        this.checkTime = checkTime;
        this.comment = comment;
        this.snowFlow = snowFlow;
    }
}
