// Just add this script to your camera. It doesn't need any configuration.
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WindowsCamera : MonoBehaviour
{


    public CubeManager cubeManager;
    public SelectionBox selectionBox;
    public InteractionMenu interactionMenu;
    public LeftJoystick leftJoystick;
    public CityButtons cityButtons;
    public GameObject characterSelected;

    public Transform skyBoxCameraTracker;

    // inputs
    public int touch;
    public float zoom;
    public Vector2[] touchPosition;

    // memory
    private Vector2 oldTouchPosition_0;
    private Vector2 oldTouchPosition_1;
    private Vector2 firstPosition;
    private float oldTouchDistance;
    private float newTouchDistance;

    // actions
    private Vector3 MoveCam;


    // calculations
    private float x_delta_translation;
    private float y_delta_translation;
    private float x_total_translation;
    private float y_total_translation;

    private bool HasTheTouchMoved;
    private bool Objectselected;
    private bool LiftingFinger;
    private bool back;


    // zoom limits
    private readonly float minZoom = 1;
    private readonly float maxZoom = 5;

    // screen moving speed
    private readonly float HorizontalSpeedRatio = 2f;
    private readonly float VerticalSpeedRatio = 2f;

    // Platform tracker
    private bool isMobile;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) isMobile = true;
    }


    void Update()
    {

        if (isMobile==true)  GetInputFromMobile(); else GetInputFromWindows();
        CityNavigation();

    }

    void SelectObject(Vector2 Target)
    {

        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Target);

        Vector3Int tpos = cubeManager.tileMapGround.WorldToCell(worldPoint);

        Debug.Log("cell at x:" + tpos.x + " , y:" + tpos.y + " , z:" + tpos.z);

        selectionBox.Deselect();
        if (cubeManager.Visible[tpos.x, tpos.y]!=4)
        { 
            Objectselected = true;
            selectionBox.Select(tpos.x, tpos.y);
            //interactionMenu.ActivateMenu(tpos);
        }
    }

    void Deselect()
    {
        selectionBox.Deselect();
        Objectselected = false;
        interactionMenu.DesactivateMenu();
    }

    void CityNavigation() {


        //select only if i touched and didn't move until i lifted my finger
        if (LiftingFinger==true && HasTheTouchMoved == false) SelectObject(touchPosition[0]);
        
        //Get out of the Character view if I click Back
        if (back == true && Objectselected == false) cityButtons.ClickMenu(1);

        //deselect if I start moving around
        if ((HasTheTouchMoved == true || back == true) && Objectselected == true) Deselect();


        // Tracking the character selected if moving with joystick
        if(leftJoystick.moveDetectedOnJoystick>=1) 
        {

            if (characterSelected == null) characterSelected = cubeManager.playerInstantiated.gameObject;

            // Finding distance between character and camera
            float x_translation = characterSelected.transform.position.x - transform.position.x;
            float y_translation = characterSelected.transform.position.y - transform.position.y;

            //Moving Camera towards character
            transform.position = new Vector3(transform.position.x + x_translation * Time.deltaTime, transform.position.y + y_translation * Time.deltaTime, transform.position.z);

            // Moving the skybox to match
            skyBoxCameraTracker.position = new Vector3(0.95f * transform.position.x, 2.5f + 0.95f * transform.position.y, 0);
        }
        // Moving around with one finger on the screen
        if (touch == 1 && leftJoystick.moveDetectedOnJoystick<=1)
        {
            // resetting the camera to free movement
            leftJoystick.moveDetectedOnJoystick = 0;

            // Calculating the movement needed
            MoveCam = transform.position + transform.TransformDirection(x_delta_translation, y_delta_translation, 0);

            // Setting the new position of the camera
            transform.position = new Vector3(
                    Mathf.Min(Mathf.Max(MoveCam.x, 0.25f * cubeManager.MinVisibleSizeOnX - 0.25f* cubeManager.MaxVisibleSizeOnY - 5), 0.25f * cubeManager.MaxVisibleSizeOnX - 0.25f * cubeManager.MinVisibleSizeOnY + 5), 
                    Mathf.Min(Mathf.Max(MoveCam.y, 0.25f * cubeManager.MinVisibleSizeOnX + 0.25f* cubeManager.MinVisibleSizeOnY - 2.5f), 0.25f * cubeManager.MaxVisibleSizeOnX + 0.25f * cubeManager.MaxVisibleSizeOnY + 2.5f), 
                    transform.position.z);

            // Moving the skybox to match
            skyBoxCameraTracker.position = new Vector3(0.95f * transform.position.x, 2.5f+0.95f * transform.position.y, 0);

            // Saving the latest position
            oldTouchPosition_0 = touchPosition[0];
        }

        // If joystick was released, then freeing up camera for next touch
        if (leftJoystick.moveDetectedOnJoystick == 2) leftJoystick.moveDetectedOnJoystick = 1;

        // Zooming and dezooming
        if (zoom != 0)
        {
            float newZoom = Mathf.Max(minZoom, Mathf.Min(maxZoom, GetComponent<Camera>().orthographicSize - zoom));
            float sizeRatio = (newZoom - minZoom) / (maxZoom - minZoom);
            GetComponent<Camera>().orthographicSize = newZoom;
            skyBoxCameraTracker.localScale = new Vector3(1 + sizeRatio, 1 + sizeRatio, 1 + sizeRatio);
        }



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
        y_delta_translation = (oldTouchPosition_0.y - touchPosition[0].y) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * VerticalSpeedRatio;

        x_total_translation = (firstPosition.x - touchPosition[0].x) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * HorizontalSpeedRatio;
        y_total_translation = (firstPosition.y - touchPosition[0].y) * GetComponent<Camera>().orthographicSize / GetComponent<Camera>().pixelHeight * VerticalSpeedRatio;

        HasTheTouchMoved = (x_total_translation + y_total_translation > 0.1);
    }


}
