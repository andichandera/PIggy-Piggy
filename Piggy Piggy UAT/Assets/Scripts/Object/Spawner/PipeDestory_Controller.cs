using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDestory_Controller : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Pipe")
        {
            Destroy(col.gameObject.transform.parent.gameObject);
        }
        if (col.gameObject.tag == "Coin" || col.gameObject.tag == "Coin 1" || col.gameObject.tag == "Coin 2" || col.gameObject.tag == "Coin 3")
        {
            Destroy(col.gameObject);
        }
    }
}
