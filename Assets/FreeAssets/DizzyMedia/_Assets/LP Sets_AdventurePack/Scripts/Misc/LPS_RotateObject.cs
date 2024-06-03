using UnityEngine;
using System.Collections;

public class LPS_RotateObject : MonoBehaviour {

    public bool canRotate;
    
    public float rotationSpeed = 2f;
    public Transform thisTransform;
    
    public Vector3 rotVect;
    
    public Quaternion resetRot;

    void Start() {
        
        //origVect = thisTransform.rotation;
        
    }//Start

    void Update() {
        
        if(canRotate){
            
            thisTransform.RotateAround(thisTransform.position, rotVect, rotationSpeed * Time.deltaTime);
    
        }//canRotate
        
    }//Update
    
    public void Reset_Rotation(){
        
        thisTransform.rotation = resetRot;
        
    }//Reset_Rotation
    
}//PAI_RotateObject
