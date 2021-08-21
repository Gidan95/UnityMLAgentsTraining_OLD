using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
public class PlayerScript : Agent
{

    [SerializeField]
    private Transform objective;
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    float speed = 0.1f;
    [SerializeField]
    private Transform wallsParent;
    [SerializeField]
    private Transform floorsParent;

    private List<Transform> walls;
    private List<Transform> floors;

    private void Start() {
        Debug.Log(this.name);
        walls = new List<Transform>();
        floors = new List<Transform>();

        for (int i=0; i < wallsParent.childCount; i++){
            walls.Add(wallsParent.GetChild(i));
        }
        for (int i=0; i < floorsParent.childCount; i++){
            floors.Add(floorsParent.GetChild(i));
        }
        
        
        
    }

    public override void OnEpisodeBegin(){

        Time.timeScale=1f;
        int playerRoom = Random.Range(0, floors.Count);
        int objRoom = Random.Range(0, floors.Count);
        if(objRoom==playerRoom){
            objRoom = objRoom+1;
            if(objRoom == floors.Count){
                objRoom=0;
            }
        }

        foreach(Transform f in floors){
            f.GetComponent<Floor>().Reinitialize();
        }

        this.transform.localPosition = floors[playerRoom].localPosition + new Vector3(0,1f,0) + new Vector3(Random.Range(-3f,3f),0,Random.Range(-3f,3f));
        objective.localPosition = floors[objRoom].localPosition + new Vector3(0,1.5f,0) + new Vector3(Random.Range(-3f,3f),0,Random.Range(-3f,3f));
        
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        int zMovement = 0;
        if(Input.GetAxisRaw("Vertical") > 0){
            zMovement = 1;
        }else if(Input.GetAxisRaw("Vertical") < 0){
            zMovement = 2;
        }
        int xMovement = 0;
        if(Input.GetAxisRaw("Horizontal") > 0){
            xMovement = 1;
        }else if(Input.GetAxisRaw("Horizontal") < 0){
            xMovement = 2;
        }

        var discreteActions = actionsOut.DiscreteActions;
        discreteActions[0]=xMovement;
        discreteActions[1]=zMovement;
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        var discreteActions = actionBuffers.DiscreteActions;

        float xMovement=discreteActions[0];
        float zMovement=discreteActions[1];
        if (discreteActions[0]==2){
                xMovement=-1;
        }
        if (discreteActions[1]==2){
                zMovement=-1;
        }




        Vector3 direction = new Vector3(xMovement,0,zMovement)* speed;
        rigidbody.MovePosition(transform.position + direction);

        AddReward(-Vector3.Distance(this.transform.localPosition,objective.localPosition)/MaxStep);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(objective.localPosition);
        sensor.AddObservation(new Vector3(transform.localPosition.x-objective.localPosition.x,0,transform.localPosition.z-objective.localPosition.z));
    }

        private void OnTriggerEnter(Collider other) {
        if(other.tag=="Wall"){
            SetReward(-1f);
            EndEpisode();
        }else if(other.tag=="Objective"){
            AddReward(1f);
            EndEpisode();
        }
    }

    
}
