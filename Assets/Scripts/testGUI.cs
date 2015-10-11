using UnityEngine;
using System.Collections;

public class testGUI : MonoBehaviour {


	private BaseClass Class1 = new LordClass();
	private BaseClass Class2 = new ButcherClass();


	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}


	void OnGUI () {
		GUILayout.Label (Class1.ClassName);
		GUILayout.Label (Class1.ClassDescription);
		GUILayout.Label (Class2.ClassName);
		GUILayout.Label (Class2.ClassDescription);
	}
}
