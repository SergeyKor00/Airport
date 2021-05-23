using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct TechCount
{
    public int type;
    public int count;

    public TechCount(int type, int count)
    {
        this.type = type;
        this.count = count;
    }
}

public class MainAlgorithm
{
    public List<int> GetOperationList(int ID)
    {
        DataRepository dataRepository = new DataRepository();

        //List<Mechanism> mechanisms = dataRepository.SelectFreeMech();

        Regions region = dataRepository.SelectFromReg(ID);

        List<int> result = new List<int>();

        if (region.snow < 1.0)
        {
            result.Add(1);
        } else {
            result.Add(3);
        }

        if (region.ice > 0)
        {
            result.Add(2);
        }

        return result;
    }

    public List<TechCount> GetTechCountList(int regId, List<int> typeLst)
    {
        DataRepository dataRepository = new DataRepository();
        List<TechCount> techCounts = new List<TechCount>();
        for(int i = 0; i < typeLst.Count; i++)
        {
            RegTechCount regTechCount = dataRepository.RegTechCountSelect(regId, typeLst[i]);
            techCounts.Add(new TechCount(regTechCount.type, regTechCount.count));
        }

        return techCounts;
    }

    public List<Mechanism> GetMechList(List<TechCount> techCounts)
    {
        DataRepository dataRepository = new DataRepository();
        List<Mechanism> mechanisms = dataRepository.SelectFreeMech();

        List<Mechanism> result = new List<Mechanism>();

        for(int i = 0; i < techCounts.Count; i++)
        {
            int count = 0;
            for(int j = 0; j < mechanisms.Count && count < techCounts[i].count; j++)
            {
                if (mechanisms[j].type == techCounts[i].type)
                {
                    result.Add(mechanisms[j]);
                    count++;
                }
            }
        }

        return result;

    }
}

//if(region.snow < 1.0)
//{

//    for (int i = 0; i < 4 || i < mechanisms.Count ; i++)
//    {
//        if (mechanisms[i].type == 1) result.Add(mechanisms[i]);
//    }
//} else if (region.snow < 1.0 && region.snowFlow == 1) {
//    for (int i = 0; i < 4 || i < mechanisms.Count; i++)
//    {
//        if (mechanisms[i].type == 3) result.Add(mechanisms[i]);
//    }
//} else {

//    for (int i = 0; i < 4 || i < mechanisms.Count; i++)
//    {
//        if (mechanisms[i].type == 3) result.Add(mechanisms[i]);
//    }
//}

//if (region.ice > 0)
//{

//    for (int i = 0; i < 4 || i < mechanisms.Count; i++)
//    {
//        if (mechanisms[i].type == 2) result.Add(mechanisms[i]);
//    }
//}
