using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Creature"){
            Destroy(gameObject);
            other.gameObject.GetComponent<CreatureController>().Stats.foodEaten++;
            other.gameObject.GetComponent<CreatureController>().Stats.FoodPos = null;
        }
    }
}
