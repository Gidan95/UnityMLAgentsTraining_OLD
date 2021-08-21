
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    Material okMaterial;
    [SerializeField]
    Material koMaterial;
    [SerializeField]
    Material warningMaterial;
    private MeshRenderer meshRenderer;
    [SerializeField]
    PlayerScript cs;


private bool isActivated = false;
    float activationTime = 0;
    public float redActivationTime = 0;

    void Start()
    {
        //Initialize floor with safe material and set its tag to GreenFloor
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material=okMaterial;
        this.tag="GreenFloor";
    }

    public void Reinitialize(){
        //Reinitialize the floor as a new episode starts
        isActivated = false;
        activationTime = 0;
        redActivationTime = 0;
        meshRenderer.material=okMaterial;
        this.tag="GreenFloor";
    }

    void Update(){
        
        //If this floor has been activated by the game system script and the warning floor time has passed
        if(isActivated && Time.timeSinceLevelLoad - activationTime > 2){
            meshRenderer.material = koMaterial;
            this.tag="RedFloor";
            if(redActivationTime == 0){
                redActivationTime = Time.timeSinceLevelLoad;
            }
        }
        //If this floor has been activated by the game system script and the warning floor time has passed
        if(isActivated && redActivationTime!=0 && Time.timeSinceLevelLoad - redActivationTime > 1.5){
            activationTime=0;
            redActivationTime=0;
            isActivated=false;
            meshRenderer.material=okMaterial;
            this.tag="GreenFloor";
        }
        
    }

   
    

    
    void Activate(){
        
        if(!isActivated){
            isActivated = true;
            activationTime = Time.timeSinceLevelLoad;
            meshRenderer.material = warningMaterial;
            this.tag="YellowFloor";
        }
        
    }
}