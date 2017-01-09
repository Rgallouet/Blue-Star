using UnityEngine;
using System.Collections;

public class SelectionBox : MonoBehaviour {

    private GameObject Selectionbox;



	// Use this for initialization
	void Start () {
        Selectionbox = GetComponent<GameObject>();
        Selectionbox.transform.position = new Vector3(0, -10, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}


}
