using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    int time = 0;
    UnityEngine.AI.NavMeshAgent agent;
    public DataStats Stats = new DataStats();
    int direct = -1;

    // Start is called before the first frame update
    void Start()
    {   
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GameObject Sphere = gameObject.transform.GetChild(0).gameObject;
        Sphere.transform.localScale = new Vector3(Stats.sense, Stats.sense, Stats.sense);
        agent.speed = Stats.speed;
        GlobalData.totspeed += Stats.speed;
        GlobalData.numagents += 1;
    }

    // Update is called once per frame
    void Update()
    {   
            GotoFood(Stats.FoodPos, Stats.FoodPos != null? true:false);
        if(time >= 100){
            Wander(agent);
            Stats.stamina--;
            time = 0;
        }
        NewDay();
        time++;
    }

    void Wander(UnityEngine.AI.NavMeshAgent agent){
        agent.destination = new Vector3(this.transform.position.x + Random.Range(-Stats.walkingdistance, Stats.walkingdistance) ,0, this.transform.position.z + Random.Range(-Stats.walkingdistance,Stats.walkingdistance));
    }

    void GotoFood(Transform loc, bool found){
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GameObject Plane = GameObject.Find("Plane");
        DayNight Day = Plane.GetComponent<DayNight>();
                if(Stats.foodEaten >= 2){
                    if(direct==-1){
                        direct = Random.Range(0,4);
                    }
                    if(direct == 0){
                        agent.destination = new Vector3(gameObject.transform.position.x, 1, 45);
                    }else if(direct == 1){
                        agent.destination = new Vector3(gameObject.transform.position.x, 1, -45);
                    }else if(direct == 2){
                        agent.destination = new Vector3(45, 1, gameObject.transform.position.z);
                    }else if(direct == 3){
                        agent.destination = new Vector3(-45, 1, gameObject.transform.position.z);
                    }
                    return;
                }else if(Stats.foodEaten >= 1 && Day.time <= 300){
                    agent.destination = new Vector3(gameObject.transform.position.x, 1, 45);
                    return; 
                }else if(found){
                    agent.destination = loc.position;
                }
    }

    void NewDay(){
        if(Stats.currentDay < GlobalData.currentDay){
            if(gameObject.transform.position.x != 45 && gameObject.transform.position.z != 45 && gameObject.transform.position.z != -45 && gameObject.transform.position.x != -45){
                GlobalData.totspeed -= Stats.speed;
                GlobalData.numagents -= 1;
                Destroy(this.gameObject);
                Debug.Log("Destroy");
                return;
            } else if(Stats.foodEaten >= 2){
                Reproduce();
            }
            Stats.currentDay = GlobalData.currentDay;
            Stats.foodEaten = 0;
            Stats.stamina = Stats.maxStamina;
            direct = -1;
            Debug.Log("NewDay");
        }
    }

    void Reproduce(){
        GameObject instantiated = Instantiate(gameObject ,gameObject.transform.position, Quaternion.identity);
        CreatureController script = instantiated.GetComponent<CreatureController>();
        script.Stats.sense = Stats.sense + Random.Range(-2, 2);
        script.Stats.speed = Stats.speed + Random.Range(-5, 5);
    }
}
