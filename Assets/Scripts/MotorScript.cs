using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MotorScript : MonoBehaviour {
    public Transform centerOfMass;
    public float enginePower = 400f;
    public float turnPower = 10f;
    public WheelScript[] wheel;
    Rigidbody rbody;

    private void Awake(){
        rbody = GetComponent<Rigidbody>(); 
    }
    void Start(){
        rbody.centerOfMass = centerOfMass.localPosition;
    }



    void FixedUpdate () {
        float torque = Input.GetAxis("Vertical") * enginePower;
        float turnSpeed = Input.GetAxis("Horizontal") * turnPower;

        if (torque != 0)
        {
            //front wheel drive
            wheel[0].Move(torque);
            wheel[1].Move(torque);

            //back wheel drive
            //        wheel[2].Move(torque);
            //        wheel[3].Move(torque);
        }
        //front wheel steering
        wheel[0].Turn(turnSpeed);
        wheel[1].Turn(turnSpeed);

        //back wheel steering
//        wheel[2].Turn(turnSpeed);
//        wheel[3].Turn(turnSpeed);
    }
}
