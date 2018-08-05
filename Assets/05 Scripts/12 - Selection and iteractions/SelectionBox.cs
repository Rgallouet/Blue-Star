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
        Selectionbox.transform.position = SelectedObject.position;
        
    }

    public void Deselect()
    {
        Selectionbox.transform.position = IdlePosition;

    }

}
