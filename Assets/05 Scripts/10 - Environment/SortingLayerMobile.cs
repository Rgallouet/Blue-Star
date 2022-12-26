using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerMobile : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt((transform.position.y + transform.position.x) * 10f) * -1;
    }
}
