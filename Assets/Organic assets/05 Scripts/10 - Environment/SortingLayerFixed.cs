using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerFixed : MonoBehaviour
{

    public float Offset;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt((transform.position.z + transform.position.x) * 10f + Offset) * -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
