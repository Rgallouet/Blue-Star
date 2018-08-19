using UnityEngine;
using System.Collections;

public class SelectionBox : MonoBehaviour {

    private Transform Selectionbox;

    private Vector3 IdlePosition = new Vector3(0, -10, 0);


    // Use this for initialization
    void Start () {
        Selectionbox = GetComponent<Transform>();
        Selectionbox.transform.position = IdlePosition;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Select(Transform SelectedObject)
    {
        Selectionbox.transform.position = new Vector3(SelectedObject.position.x, SelectedObject.position.y+0.01f, SelectedObject.position.z);


    }

    public void Deselect()
    {
        Selectionbox.transform.position = IdlePosition;

    }

}
