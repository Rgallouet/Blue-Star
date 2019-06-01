using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerMobile : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt((transform.position.z + transform.position.x) * 10f) * -1;
    }
}
