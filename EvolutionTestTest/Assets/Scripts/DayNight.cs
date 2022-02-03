using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{

    [SerializeField]
    public int time = 5000;
    // Update is called once per frame
    void FixedUpdate()
    {
        time --;
        GlobalData.avgspeed = GlobalData.totspeed / GlobalData.numagents;
        Debug.Log(GlobalData.avgspeed);

        if(time <= 0){
            GlobalData.currentDay++;
            time = 5000;
        }
    }
}
