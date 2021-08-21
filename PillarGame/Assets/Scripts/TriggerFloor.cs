using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFloor : MonoBehaviour
{
    Floor floor;
    [SerializeField]
    PlayerScript cs;

    private void Start() {
        floor=this.transform.parent.GetComponent<Floor>();
    }
    // Start is called before the first frame update
     private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Player") && floor.redActivationTime > 0f){
            cs.AddReward(-1f);
            cs.EndEpisode();
        }
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag.Equals("Player") && floor.redActivationTime > 0f){
            cs.AddReward(-1f);
            cs.EndEpisode();
        }
        
        
    }
}
