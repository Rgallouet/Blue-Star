// Just add this script to your camera. It doesn't need any configuration.

using UnityEngine;
using UnityEngine.UI;

public class WindowsCamera : MonoBehaviour
{


    public CubeManager cubeManager;
    public SelectionBox selectionBox;
    public InteractionMenu interactionMenu;
    public JoystickMenu joystickMenu;
    public CityButtons cityButtons;

    public bool CharacterViewMode;
    public GameObject characterSelected;

    public int touch;
    private float zoom;
    public Vector2[] touchPosition;
    public Vector2 oldTouchPosition_0;
    public Vector2 oldTouchPosition_1;

    private Vector2 firstPosition;

    public Vector3 MoveCam;

    public float HorizontalSpeedRatio = 2f;
    public float VerticalSpeedRatio = 4.5f;

    float oldTouchDistance;
    float newTouchDistance;

    private float x_delta_translation;
    private float z_delta_translation;
    public float x_total_translation;
    public float z_total_translation;

    public bool HasTheTouchMoved;
    public bool Objectselected;
    public bool LiftingFinger;
    public bool back;



    private float minZoom = 3;
    private float maxZoom = 15;



    void Update()
    {

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)  GetInputFromMobile(); else GetInputFromWindows();

        if (CharacterViewMode == false) CityView(); else CharacterView();
    }

    public bool SelectObject(Vector2 Target)
    {

        RaycastHit hitInfo = new RaycastHit();

        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Target), out hitInfo);
        
        if (hit)
        {
            Objectselected = true;
            selectionBox.Select(hitInfo.transform.gameObject);
            interactionMenu.ActivateMenu(hitInfo.transform.gameObject);
        }

        return hit;
    }

    void Deselect()
    {
        selectionBox.Deselect();
        Objectselected = false;
        interactionMenu.DesactivateMenu();
    }

    void CityView() {


        //select only if i touched and didn't move until i lifted my finger
        if (LiftingFinger==true && HasTheTouchMoved == false) SelectObject(touchPosition[0]);
        
        //Get out of the Character view if I click Back
        if (back == true && Objectselected == false) cityButtons.ClickMenu(1);

        //deselect if I start moving around
        if ((HasTheTouchMoved == true || back == true) && Objectselected == true) Deselect();

        // Moving around with one finger on the screen
        if (touch == 1)
        {
                MoveCam = transform.position + transform.TransformDirection(x_delta_translation, 0, z_delta_translation);
                transform.position = new Vector3(Mathf.Min(Mathf.Max(MoveCam.x, 0), cubeManager.MapSizeOnX - 5), transform.position.y, Mathf.Min(Mathf.Max(MoveCam.z, 0), cubeManager.MapSizeOnZ - 5));
                oldTouchPosition_0 = touchPosition[0];
        }
        
        // Zooming and dezooming
       GetComponent<Camera>().orthographicSize = Mathf.Max(minZoom, Mathf.Min(maxZoom, GetComponent<Camera>().orthographicSize - zoom));




    }
    
    void CharacterView()
    {


        //select only if i touched and didn't move until i lifted my finger
        if (LiftingFinger == true && HasTheTouchMoved == false) SelectObject(touchPosition[0]);

        //Get out of the Character view if I click Back
        if (back == true && Objectselected == false) joystickMenu.DesactivateJoystick();

        //deselect if I start moving around or click back
        if ( (HasTheTouchMoved == true || back==true ) && Objectselected == true) Deselect();

        // Tracking the character selected
        float x_translation = characterSelected.transform.position.x - transform.position.x - 3.5f;
        float z_translation = characterSelected.transform.position.z - transform.position.z - 3.5f;
        transform.position = new Vector3(transform.position.x + x_translation*Time.deltaTime, transform.position.y, transform.position.z + z_translation * Time.deltaTime);

        // Zooming and dezooming
        GetComponent<Camera>().orthographicSize = Mathf.Max(minZoom, Mathf.Min(maxZoom, GetComponent<Camera>().orthographicSize - zoom));



    }

    void GetInputFromMobile() {

        touch = Input.touchCount;

        //Re-initialise settings when no more touch on the screen
        if (touch == 0)
        {
            oldTouchPosition_0 = Vector2.zero;
            oldTouchPosition_1 = Vector2.zero;
            firstPosition= Vector2.zero;
        }

        // When I sense one finger on the screen, i record its position on 0, forget if i had a 2 finger, and trace the historic point where I started touching the screen
        if (touch == 1)
        {
            touchPosition[0] = Input.GetTouch(0).position;
            if (oldTouchPosition_0 == Vector2.zero) { firstPosition= touchPosition[0]; oldTouchPosition_0 = touchPosition[0];}
            if (oldTouchPosition_1 != Vector2.zero) oldTouchPosition_1 = Vector2.zero;
            

        }

        // When I record two or more fingers on the screen, i record the first and second positions on 0 and 1.
        if (touch > 1)
        {
            touchPosition[0] = Input.GetTouch(0).position;
            touchPosition[1] = Input.GetTouch(1).position;

            if (oldTouchPosition_1 == Vector2.zero)
            {
                oldTouchPosition_0 = touchPosition[0];
                oldTouchPosition_1 = touchPosition[1];
            }

            // je met a jour les distances
            oldTouchDistance = (oldTouchPosition_0 - oldTouchPosition_1).magnitude;
            newTouchDistance = (touchPosition[0] - touchPosition[1]).magnitude;

            // Je get mon zoom
            zoom = GetComponent<Camera>().orthographicSize * (1 - (oldTouchDistance / newTouchDistance));

            // Je reset pour la prochaine fois
            oldTouchPosition_0 = touchPosition[0];
            oldTouchPosition_1 = touchPosition[1];
        }
        else zoom = 0;

        LiftingFinger = touch > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;

        back = Input.GetKeyDown(KeyCode.Escape);

        TouchMoved();


    }

    void GetInputFromWindows() {

        //Get the input
        if (Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
        {
            touch = 1;
            touchPosition[0] = Input.mousePosition;
            if (oldTouchPosition_0 == Vector2.zero) { oldTouchPosition_0 = touchPosition[0]; firstPosition = touchPosition[0]; }
            if (oldTouchPosition_1 != Vector2.zero) oldTouchPosition_1 = Vector2.zero;
        }
        else
        {
            touch = 0;
            oldTouchPosition_0 = Vector2.zero;
            oldTouchPosition_1 = Vector2.zero;
            firstPosition = Vector2.zero;

        }

        zoom = Input.GetAxis("Mouse ScrollWheel");

        LiftingFinger = Input.GetMouseButtonUp(0);

        back = Input.GetMouseButtonUp(1);

        TouchMoved();
    }

    void TouchMoved() {

        x_delta_translation = (oldTouchPosition_0.x - touchPosition[0].x) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * HorizontalSpeedRatio;
        z_delta_translation = (oldTouchPosition_0.y - touchPosition[0].y) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * VerticalSpeedRatio;

        x_total_translation = (firstPosition.x - touchPosition[0].x) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * HorizontalSpeedRatio;
        z_total_translation = (firstPosition.y - touchPosition[0].y) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * VerticalSpeedRatio;

        HasTheTouchMoved = (x_total_translation + z_total_translation > 0.1);
    }


}
