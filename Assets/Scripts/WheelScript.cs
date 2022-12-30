using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class WheelScript : MonoBehaviour {
    const string TIRE_NAME = "Tire";

    [SerializeField]Transform tire;
    WheelCollider wc;

    private void Awake(){
        wc = GetComponent<WheelCollider>();
//        if(tire == null)
//            tire = transform.FindChild(TIRE_NAME);
    }

    public void Move(float value){
        wc.motorTorque = value;
    }

    public void Turn(float value) {
        wc.steerAngle = value;
        tire.localEulerAngles = new Vector3(0f, wc.steerAngle, 0f);
    }
	
}
