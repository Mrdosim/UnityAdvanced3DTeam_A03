using UnityEngine;
using System.Collections;

public class LPS_ManualRotate : MonoBehaviour {
    
    public float rotSpeed = 20;
    
    public Transform rotTrans;
    
    private float rotX;
    
    void OnMouseDrag() {
    
        rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        rotTrans.RotateAround(Vector3.up, -rotX);
    
    }//OnMouseDrag
}
