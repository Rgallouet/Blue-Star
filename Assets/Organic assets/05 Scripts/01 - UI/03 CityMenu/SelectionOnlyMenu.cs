using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionOnlyMenu : MonoBehaviour
{
    private Canvas selectionOnlyCanvas;


    // Start is called before the first frame update
    void Start()
    {
        selectionOnlyCanvas = GetComponent<Canvas>();
        DesactivateMenu();
    }

    public void DesactivateMenu()
    {
        selectionOnlyCanvas.enabled = false;
    }
    public void ActivateMenu()
    {
        selectionOnlyCanvas.enabled = true;

    }

    

}
