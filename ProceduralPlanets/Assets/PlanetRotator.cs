using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
	public float rotateSpeed = 10;

    // Update is called once per frame
    void Update()
    {
		Vector3 pos = new Vector3 {y = 0.5f * Mathf.Sin(Time.time * 1.5f)};
		transform.position = pos;
        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
