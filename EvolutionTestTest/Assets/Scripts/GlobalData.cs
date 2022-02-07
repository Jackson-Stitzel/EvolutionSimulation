using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static int currentDay = 0;
    public static float totspeed = 0;
    public static float totsense = 0;
    public static float numagents = 0;
    public static float avgspeed = totspeed/numagents;
    public static float avgsense = totsense/numagents;
}
