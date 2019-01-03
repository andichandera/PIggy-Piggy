using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Jump_Controller : MonoBehaviour {
    public Collider2D PlayButton, CreditButton, BackButton, CancelButton, ConfirmButton;
    public GameObject CreditUI,ExitUI;
    // Use this for initialization
    void Start () {
        
    }
	// Update is called once per frame
	void Update () {
        Vector2 contactPoint = Vector2.zero;

        if (Input.touchCount > 0)
            contactPoint = Input.touches[0].position;
        if (Input.GetMouseButtonDown(0))
            contactPoint = Input.mousePosition;

        if (PlayButton == Physics2D.OverlapPoint
                (Camera.main.ScreenToWorldPoint(contactPoint)))
        {
            GameStateManager.GameState = GameState.Intro;
            //GetComponent<AudioSource>().PlayOneShot(RestartAudioClip);
            Application.LoadLevel(Application.loadedLevelName);
            SceneManager.LoadScene("Games");
        }
        else if (CreditButton == Physics2D.OverlapPoint
                (Camera.main.ScreenToWorldPoint(contactPoint)))
        {
            CreditUI.SetActive(true);
        }
        else if (BackButton == Physics2D.OverlapPoint
                (Camera.main.ScreenToWorldPoint(contactPoint)))
        {
            CreditUI.SetActive(false);
        }
        else if (CancelButton == Physics2D.OverlapPoint
                (Camera.main.ScreenToWorldPoint(contactPoint)))
        {
            Application.CancelQuit();
        }
        else if (ConfirmButton == Physics2D.OverlapPoint
                (Camera.main.ScreenToWorldPoint(contactPoint))) 
        {
            Application.Quit();
        }
        if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Canceled) || Input.GetKeyDown(KeyCode.A))
        {
            ExitUI.SetActive(true);
        }
    }

}
