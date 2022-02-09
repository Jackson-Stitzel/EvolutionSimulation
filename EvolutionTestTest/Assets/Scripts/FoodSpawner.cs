using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField]
    public Transform Food = null;

    int groundSize = 10; 
    void Start(){
        SpawnFood(groundSize, Food);
    }

    public static void SpawnFood(int groundwidth, Transform Food){
        for(int i = -10/2;i<groundwidth/2; i++){
            for(int j = -10/2; j < groundwidth/2;j++){
                if(Random.Range(0, 10) <= 5){
                    Debug.Log("Test");
                    Instantiate(Food,new Vector3((10*i)+5, 1, (10*j)+5), Quaternion.identity);
                }
            }
        }
    }
}
