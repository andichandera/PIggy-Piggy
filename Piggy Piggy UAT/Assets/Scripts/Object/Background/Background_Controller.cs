using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Controller : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveDown();
	}
    
    public void MoveDown()
    {
        if (gameObject.transform.localPosition.x <= -9.2f)
        {
            gameObject.transform.localPosition = new Vector3(16f, 0f, 1f);
        }
        else
        {

        }
        {
            gameObject.transform.localPosition = new Vector3(0f, speed, 0f);
        }
    }
}
