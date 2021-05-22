using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAlgorithm
{
    public List<Mechanism> Start(int ID)
    {
        DataRepository dataRepository = new DataRepository();

        List<Mechanism> mechanisms = dataRepository.SelectFreeMech();

        List<Regions> regions = dataRepository.SelectFromReg(ID);

        List<Mechanism> result = new List<Mechanism>();

        if(regions[0].snow < 1.0 && regions[0].ice == 0 && regions[0].snowFlow == 0 && regions[0].ID <= 3)
        {
            dataRepository.InsertIntoTask(regions[0].ID, 0, 1, 55, 38);
            for (int i = 0; i < 4 || i < mechanisms.Count ; i++)
            {
                 result.Add(mechanisms[i]);
            }
        }

        return result;
    }
}
