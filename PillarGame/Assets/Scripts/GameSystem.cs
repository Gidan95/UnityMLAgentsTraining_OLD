using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{

    [SerializeField]
    Material okMaterial;
    [SerializeField]
    Material koMaterial;
    [SerializeField]
    Material warningMaterial;

    [SerializeField]
     Transform room;
     private List<GameObject> floors;

    // Start is called before the first frame update
    void Start()
    {
        //I need to set this otherwise when i test my model it fucks up tremendously
        Time.timeScale=1.0f;
        floors = new List<GameObject>();
        //rooms = GameObject.FindGameObjectsWithTag("Room");
        foreach(Transform child in room){
            //GameObject floor = r.transform.c("Floor").gameObject;
            GameObject floor = child.gameObject;
            floors.Add(floor);
            //Debug.Log(floor.name);
        }
    }

    private float lastActivationTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad - lastActivationTime > 0.75f){
           // GameObject room = rooms[Random.Range(0, rooms.Length)];
            //GameObject floor = room.transform.Find("Floor").gameObject;
            //Debug.Log(floors.Count);
            GameObject floor = floors[Random.Range(0, floors.Count)];
            floor.SendMessage("Activate");
            lastActivationTime=Time.timeSinceLevelLoad;
        }
    }
}
