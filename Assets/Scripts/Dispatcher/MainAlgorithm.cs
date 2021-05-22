using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        return result;
    }
}
