using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RegTechCount
{
    public int ID;
    public int RegID;
    public int type;
    public int count;

    public RegTechCount(int iD, int regID, int type, int count)
    {
        ID = iD;
        RegID = regID;
        this.type = type;
        this.count = count;
    }
}

