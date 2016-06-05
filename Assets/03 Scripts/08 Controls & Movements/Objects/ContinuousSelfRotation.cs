using UnityEngine;
using System.Collections;

public class ContinuousSelfRotation : MonoBehaviour {

    public float XRotateSpeed=50;
    public float YRotateSpeed = 50;
    public float ZRotateSpeed = 50;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(XRotateSpeed * Time.deltaTime, YRotateSpeed * Time.deltaTime, ZRotateSpeed * Time.deltaTime); //rotates degrees per second around z axis

    }
}
