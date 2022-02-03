using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sense : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Food"){
            GameObject Obj = this.transform.parent.gameObject;
            Obj.GetComponent<CreatureController>().Stats.FoodPos = other.transform;
        }
    }
}
