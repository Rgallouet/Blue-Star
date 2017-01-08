// Just add this script to your camera. It doesn't need any configuration.

using UnityEngine;

public class AndroidCamera : MonoBehaviour {

    public CubeManager cubeManager;

    public int touch;
    public Vector2 touchPosition;

    Vector2?[] oldTouchPositions = { null, null};

	public Vector2 oldTouchVector;
    public Vector3 MoveCam;

    public float HorizontalSpeedRatio = 2f;
    public float VerticalSpeedRatio=4.5f;

	float oldTouchDistance;




	void Update() {

        
        if (Input.touchCount == 0) {
			oldTouchPositions[0] = null;
			oldTouchPositions[1] = null;
        }
		else if (Input.touchCount == 1) {

			if (oldTouchPositions[0] == null || oldTouchPositions[1] != null) {
				oldTouchPositions[0] = Input.GetTouch(0).position;
				oldTouchPositions[1] = null;
			}
			else {
                Vector2 newTouchPosition = Input.GetTouch(0).position;
                float x_translation = (((Vector2)oldTouchPositions[0]).x - newTouchPosition.x) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * HorizontalSpeedRatio;
                float z_translation = (((Vector2)oldTouchPositions[0]).y - newTouchPosition.y) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * VerticalSpeedRatio;
         
                MoveCam = transform.position + transform.TransformDirection(x_translation, 0, z_translation);
                transform.position = new Vector3(Mathf.Min(Mathf.Max(MoveCam.x,0),cubeManager.MapSize-5), transform.position.y, Mathf.Min(Mathf.Max(MoveCam.z, 0), cubeManager.MapSize-5));

				oldTouchPositions[0] = newTouchPosition;
			}
		}
        else {
			if (oldTouchPositions[1] == null) {
				oldTouchPositions[0] = Input.GetTouch(0).position;
				oldTouchPositions[1] = Input.GetTouch(1).position;
				oldTouchVector = (Vector2)(oldTouchPositions[0] - oldTouchPositions[1]);
				oldTouchDistance = oldTouchVector.magnitude;
			}
			else {
				Vector2[] newTouchPositions = { Input.GetTouch(0).position, Input.GetTouch(1).position };
				Vector2 newTouchVector = newTouchPositions[0] - newTouchPositions[1];
				float newTouchDistance = newTouchVector.magnitude;

                GetComponent<Camera>().orthographicSize = Mathf.Max(1, Mathf.Min(5, GetComponent<Camera>().orthographicSize * (oldTouchDistance / newTouchDistance)));


                oldTouchPositions[0] = newTouchPositions[0];
				oldTouchPositions[1] = newTouchPositions[1];
				oldTouchVector = newTouchVector;
				oldTouchDistance = newTouchDistance;
			}
		}
	}
}
