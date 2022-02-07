using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "Speed: "+ GlobalData.avgspeed.ToString() + " Sense: "+ (GlobalData.totsense/GlobalData.numagents).ToString();
    }
}
