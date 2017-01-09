// Just add this script to your camera. It doesn't need any configuration.

using UnityEngine;

public class WindowsCamera : MonoBehaviour
{

    public CubeManager cubeManager;

    public int touch;
    public Vector2 touchPosition;

    Vector2?[] oldTouchPositions = { null, null };

    public Vector2 oldTouchVector;
    public Vector3 MoveCam;

    public float HorizontalSpeedRatio = 2f;
    public float VerticalSpeedRatio = 4.5f;

    float oldTouchDistance;




    void Update()
    {

        if (Input.GetMouseButton(0)) {
            touch = 1;
            touchPosition = Input.mousePosition;
        }
        else {
            touch = 0;
            touchPosition = new Vector2(0, 0);
        }
        

        if (touch == 0)
        {
            oldTouchPositions[0] = null;
            oldTouchPositions[1] = null;

            GetComponent<Camera>().orthographicSize = Mathf.Max(1, Mathf.Min(5, GetComponent<Camera>().orthographicSize - Input.GetAxis("Mouse ScrollWheel")));


        }
        else if (touch == 1)
        {
            SelectObject();

            if (oldTouchPositions[0] == null || oldTouchPositions[1] != null)
            {
                oldTouchPositions[0] = touchPosition;
                oldTouchPositions[1] = null;
            }
            else {

                float x_translation = (((Vector2)oldTouchPositions[0]).x - touchPosition.x) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * HorizontalSpeedRatio;
                float z_translation = (((Vector2)oldTouchPositions[0]).y - touchPosition.y) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * VerticalSpeedRatio;

                MoveCam = transform.position + transform.TransformDirection(x_translation, 0, z_translation);

                transform.position = new Vector3(Mathf.Min(Mathf.Max(MoveCam.x, 0), cubeManager.MapSize - 5), transform.position.y, Mathf.Min(Mathf.Max(MoveCam.z, 0), cubeManager.MapSize - 5));

                oldTouchPositions[0] = touchPosition;
            }
        }

    }


    void SelectObject()
    {

        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit)
        {
            Debug.Log("Hit " + hitInfo.transform.gameObject.name);
        }
        else {
            Debug.Log("No hit");
        }


    }
}
