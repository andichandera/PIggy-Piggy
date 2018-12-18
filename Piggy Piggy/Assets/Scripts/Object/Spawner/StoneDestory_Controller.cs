using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDestory_Controller : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stone")
        {
            Destroy(col.gameObject.transform.parent.gameObject);
        }
    }
}
