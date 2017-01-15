using UnityEngine;
using UnityEngine.UI;

public class DebugAndroid : MonoBehaviour {

    public Text[] textbox;

    public void DebugLog(string text, int box) {

        textbox[box].text = text;

    }

}
