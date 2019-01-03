using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Helper;
using UnityEngine.SceneManagement;

public class Piggy_Piggy_Controller : MonoBehaviour
{

    #region Property
    public AudioClip FlyAudioClip, DeathAudioClip, ScoredAudioClip, CoinAudioClip, RestartAudioClip, VictoryAudioClip;
    public Sprite getReadySprite;
    public float rotateUpSpeed = 1, rotateDownSpeed = 1;
    public GameObject IntroGUI, DeadthUI,VictoryUI;
    public Collider2D restartButtonGameCollider, backButtonMenu, nextButton, BackButton1Menu;
    public float velocityPerJump = 3;
    public float xSpeed = 1;
    #endregion
    // Use this for initialization
    void Start()
    {

    }

    PiggyYAxisTravelState piggyYAxisTravelState;

    enum PiggyYAxisTravelState
    {
        GoingUp,
        GoingDown
    }

    Vector3 piggyRotation = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector2 contactPoint = Vector2.zero;

        if (Input.touchCount > 0)
            contactPoint = Input.touches[0].position;
        if (Input.GetMouseButtonDown(0))
            contactPoint = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (GameStateManager.GameState == GameState.Intro)
        {
            MovePiggyOnXAxis();
            if (WasTouchOrClicked())
            {
                GameStateManager.GameState = GameState.Playing;
                Score_Controller.Score = 0;
                IntroGUI.SetActive(false);
            }
        }
        else if (GameStateManager.GameState == GameState.Playing)
        {
            MovePiggyOnXAxis();
            if (WasTouchOrClicked())
            {
                BoostOnYAxis();
                GetComponent<AudioSource>().PlayOneShot(FlyAudioClip);
            }
        }
        else if (GameStateManager.GameState == GameState.Dead)
        {
            //check if user wants to restart the game
            if (restartButtonGameCollider == Physics2D.OverlapPoint
                (Camera.main.ScreenToWorldPoint(contactPoint)))
            {
                GameStateManager.GameState = GameState.Intro;
                GetComponent<AudioSource>().PlayOneShot(RestartAudioClip);
                Application.LoadLevel(Application.loadedLevelName);
            }
            else if (backButtonMenu == Physics2D.OverlapPoint
                (Camera.main.ScreenToWorldPoint(contactPoint)))
            {
                Score_Controller.Score = 0;
                SceneManager.LoadScene("MainMenu");
            }
        }
        if (Score_Controller.Score >= 2)
        {
            GameStateManager.GameState = GameState.Victory;
            FlappyDies();
            Score_Controller.Score = 0;
            SceneManager.LoadScene("Story");
        }


    }

    void FixedUpdate()
    {
        //just jump up and down on intro screen
        if (GameStateManager.GameState == GameState.Intro)
        {
            if (GetComponent<Rigidbody2D>().velocity.y < -1) //when the speed drops, give a boost
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GetComponent<Rigidbody2D>().mass * 5500 * Time.deltaTime)); //lots of play and stop 
                                                                                                                                //and play and stop etc to find this value, feel free to modify
        }
        else if (GameStateManager.GameState == GameState.Playing || GameStateManager.GameState == GameState.Dead)
        {
            //FixFlappyRotation();
        }
    }
    bool WasTouchOrClicked()
    {
        if (Input.GetButtonUp("Jump") || Input.GetMouseButtonDown(0) ||
            (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))
            return true;
        else
            return false;
    }

    void MovePiggyOnXAxis()
    {
        transform.position += new Vector3(Time.deltaTime * xSpeed, 0, 0);
    }

    void BoostOnYAxis()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocityPerJump);
    }



    //Check For Colison 2D
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Coin" || col.gameObject.tag == "Coin 1" || col.gameObject.tag == "Coin 2" || col.gameObject.tag == "Coin 3")
        {
            Destroy(col.gameObject);
            GetComponent<AudioSource>().PlayOneShot(CoinAudioClip);
            Score_Controller.Score++;
        }
        if (col.gameObject.tag == "AngPao")
        {
            Destroy(col.gameObject);
            GetComponent<AudioSource>().PlayOneShot(CoinAudioClip);
            Score_Controller.Score+=5;
        }
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "Pipe")
        {
            GameStateManager.GameState = GameState.Dead;
            FlappyDies();
        }
    }

    void FlappyDies()
    {
        if (GameStateManager.GameState == GameState.Dead)
        {
            DeadthUI.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(DeathAudioClip);
        }
        else
        {
            Score_Controller.Score = 0;
            SceneManager.LoadScene("Story");
        }
    }
}
