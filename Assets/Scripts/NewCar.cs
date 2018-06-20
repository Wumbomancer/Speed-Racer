using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class NewCar : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
	public float brake;
    public Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

    public void FixedUpdate()
    {
		    float motor = 0;

        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
		    float braking = brake *Input.GetAxis("Gas");
		    Debug.Log(braking);
        if(braking < 0)
		      {
			      braking = 0;
		      }
		        if(Input.GetAxis("Gas") < 0)
		          {
			             motor = maxMotorTorque * Input.GetAxis("Gas") * (-1);
		          }


        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
			if(axleInfo.brake)
			{
				axleInfo.leftWheel.brakeTorque = braking;
				axleInfo.rightWheel.brakeTorque = braking;
			}

        }
    }

	public void Update()
	{
		if(Input.GetButtonDown("Cancel"))
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
	public bool brake;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
