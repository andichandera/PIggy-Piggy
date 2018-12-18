using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

    public Transform Player;
    float camera;
    // Use this for initialization
    void Start () {
        camera = transform.position.z;
    }
    
    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(Player.position.x + 0.5f, 0, camera);
    }

    
}
