using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	public bool round;
	public float delay;
    public Transform turret;
	float radian = 0;

	void Update()
	{
		Vector3 v = new Vector3(transform.position.x, 1, transform.position.z);
		radian -= 0.05f;
		float dy = Mathf.Cos(radian) * 0.8f;
		if (!round)
			transform.position = v + new Vector3(0, dy, 0);

		if (round)
		{
			transform.position = v + new Vector3(0, dy, 0);
			transform.RotateAround(turret.position, Vector3.up, 30 * Time.deltaTime);
		}
	}
	 

	
}
