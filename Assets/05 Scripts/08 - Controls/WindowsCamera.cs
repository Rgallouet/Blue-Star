// Just add this script to your camera. It doesn't need any configuration.

using UnityEngine;
using UnityEngine.UI;

public class WindowsCamera : MonoBehaviour
{


    public CubeManager cubeManager;
    public SelectionBox selectionBox;
    public InteractionMenu interactionMenu;

    public int touch;
    public Vector2[] touchPosition;

    Vector2?[] oldTouchPositions = { null, null };

    public Vector2 oldTouchVector;
    public Vector3 MoveCam;

    public float HorizontalSpeedRatio = 2f;
    public float VerticalSpeedRatio = 4.5f;

    float oldTouchDistance;

    bool Objectselected;
    bool AsTheTouchMoved;
    

    void Update()
    {

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {

            

            touch = Input.touchCount;
            if (touch == 1) touchPosition[0] = Input.GetTouch(0).position;
            if (touch > 1)
            {
                touchPosition[0] = Input.GetTouch(0).position;
                touchPosition[1] = Input.GetTouch(1).position;
            }

            //select only if i touched and didn't move until i lifted my finger
            if (touch>0 && Input.GetTouch(0).phase == TouchPhase.Ended && AsTheTouchMoved == false) SelectObject(touchPosition[0]); 


        }
        else {


            if (Input.GetMouseButton(0))
            {
                touch = 1;
                touchPosition[0] = Input.mousePosition;
            }
            else touch = 0;

            //right clic to deselect
            if (Input.GetMouseButtonUp(1) && Objectselected == true) Deselect();

            //use scroll wheel to zoom
            if (Input.GetAxis("Mouse ScrollWheel") != 0) GetComponent<Camera>().orthographicSize = Mathf.Max(1, Mathf.Min(10, GetComponent<Camera>().orthographicSize - Input.GetAxis("Mouse ScrollWheel")));

            //select only if i clicked and didn't move until i stopped clicking
            if (Input.GetMouseButtonUp(0) && AsTheTouchMoved == false) SelectObject(touchPosition[0]);
            
            }





        //deselect if I start moving around
        if (AsTheTouchMoved == true && Objectselected == true) Deselect(); 


        if (touch == 0)
        {
            oldTouchPositions[0] = null;
            oldTouchPositions[1] = null;
            AsTheTouchMoved = false;
        }
        else if (touch == 1)
        {
            
            if (oldTouchPositions[0] == null || oldTouchPositions[1] != null)
            {
                oldTouchPositions[0] = touchPosition[0];
                oldTouchPositions[1] = null;
            }
            else {
                Vector2 newTouchPosition = touchPosition[0];
                float x_translation = (((Vector2)oldTouchPositions[0]).x - newTouchPosition.x) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * HorizontalSpeedRatio;
                float z_translation = (((Vector2)oldTouchPositions[0]).y - newTouchPosition.y) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * VerticalSpeedRatio;

                if (x_translation + z_translation > 0.1) AsTheTouchMoved = true;

                MoveCam = transform.position + transform.TransformDirection(x_translation, 0, z_translation);
                transform.position = new Vector3(Mathf.Min(Mathf.Max(MoveCam.x, 0), cubeManager.MapSize - 5), transform.position.y, Mathf.Min(Mathf.Max(MoveCam.z, 0), cubeManager.MapSize - 5));

                oldTouchPositions[0] = newTouchPosition;
            }

        }
        else {
            if (oldTouchPositions[1] == null)
            {
                oldTouchPositions[0] = touchPosition[0];
                oldTouchPositions[1] = touchPosition[1];
                oldTouchVector = (Vector2)(oldTouchPositions[0] - oldTouchPositions[1]);
                oldTouchDistance = oldTouchVector.magnitude;
            }
            else {
                Vector2[] newTouchPositions = { touchPosition[0], touchPosition[1] };
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


    void SelectObject(Vector2 Target)
    {

        RaycastHit hitInfo = new RaycastHit();

        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Target), out hitInfo);
        
        if (hit)
        {
            Objectselected = true;
            selectionBox.Select(hitInfo.transform.gameObject);
            interactionMenu.ActivateMenu(hitInfo.transform.gameObject);

        }
        else {
            Deselect();
        }
    }

    void Deselect()
    {
        selectionBox.Deselect();
        Objectselected = false;
        interactionMenu.DesactivateMenu();
    }
}
