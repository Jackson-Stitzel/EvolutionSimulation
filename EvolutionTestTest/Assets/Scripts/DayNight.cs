using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{

    [SerializeField]
    public int time = 5000;
    [SerializeField]
    Transform food = null;
    // Update is called once per frame
    void FixedUpdate()
    {
        time --;
        GlobalData.avgspeed = GlobalData.totspeed / GlobalData.numagents;
        Debug.Log(GlobalData.avgspeed);

        if(time <= 0){
            GlobalData.currentDay++;
            FoodSpawner.SpawnFood(10, food);
            time = 5000;
        }
    }
}
