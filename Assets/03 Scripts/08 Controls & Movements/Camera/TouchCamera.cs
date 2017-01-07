// Just add this script to your camera. It doesn't need any configuration.

using UnityEngine;

public class TouchCamera : MonoBehaviour {

    public CubeManager cubeManager;

    public int touch;
    public Vector2 touchPosition;

    Vector2?[] oldTouchPositions = { null, null};

	public Vector2 oldTouchVector;
    public Vector3 MoveCam;

    public float HorizontalSpeedRatio = 2f;
    public float VerticalSpeedRatio=4f;


	float oldTouchDistance;

	void Update() {

        if (Input.GetMouseButton(0) || (Input.touchCount == 1)) touch = 1;
        else if (Input.touchCount > 1) touch = 2;
        else touch = 0;

        if (Input.GetMouseButton(0)==true) touchPosition = Input.mousePosition;
        else if (Input.touchCount == 1) touchPosition = Input.GetTouch(0).position;
        else touchPosition = new Vector2(0,0);

        if (touch==0 ) {
			oldTouchPositions[0] = null;
			oldTouchPositions[1] = null;
        }
		else if (touch==1) {

			if (oldTouchPositions[0] == null || oldTouchPositions[1] != null) {
				oldTouchPositions[0] = touchPosition;
				oldTouchPositions[1] = null;
			}
			else {

                float x_translation = (((Vector2)oldTouchPositions[0]).x - touchPosition.x) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * HorizontalSpeedRatio;
                float z_translation = (((Vector2)oldTouchPositions[0]).y - touchPosition.y) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * VerticalSpeedRatio;
         
                MoveCam = transform.position + transform.TransformDirection(x_translation, 0, z_translation);
                transform.position = new Vector3(Mathf.Min(Mathf.Max(MoveCam.x,0),cubeManager.MapSize-5), transform.position.y, Mathf.Min(Mathf.Max(MoveCam.z, 0), cubeManager.MapSize-5));

				oldTouchPositions[0] = touchPosition;
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
				Vector2 screen = new Vector2(GetComponent<Camera>().pixelWidth, GetComponent<Camera>().pixelHeight);
				
				Vector2[] newTouchPositions = {
					Input.GetTouch(0).position,
					Input.GetTouch(1).position
				};
				Vector2 newTouchVector = newTouchPositions[0] - newTouchPositions[1];
				float newTouchDistance = newTouchVector.magnitude;

				transform.position += transform.TransformDirection((Vector3)((oldTouchPositions[0] + oldTouchPositions[1] - screen) * GetComponent<Camera>().orthographicSize / screen.y));
				GetComponent<Camera>().orthographicSize *= oldTouchDistance / newTouchDistance;
				transform.position -= transform.TransformDirection((newTouchPositions[0] + newTouchPositions[1] - screen) * GetComponent<Camera>().orthographicSize / screen.y);

				oldTouchPositions[0] = newTouchPositions[0];
				oldTouchPositions[1] = newTouchPositions[1];
				oldTouchVector = newTouchVector;
				oldTouchDistance = newTouchDistance;
			}
		}
	}
}
