using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatues
{
    Start,
    Pause,
    GameOver,
    Running,
    Help,
    Chap1,
    Chap2
}

public class SceneController : MonoBehaviour
{
    public GameStatues statues;                         //GameStatus, First in Start
    public GameStatues lastStatus;                      //Last Status, to remain the status before pause
    public static int MAX_SCORE = 10;
    public static int MAX_ROUND = 3;
    GUIStyle fontstyle = new GUIStyle();                //GUI

    //statric function, get input from keyboard or kinect
    static public KeyCode GetInput()
    {
        if (Input.anyKeyDown)
        {
            return Event.current.keyCode;
        } else
        {
            return KeyCode.Alpha0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //scoreKeeper = gameObject.AddComponent<ScoreKeeper>() as ScoreKeeper;
        //diskmanager = gameObject.AddComponent<DiskActionManager>() as DiskActionManager;
        //diskmanager.GetScore(scoreKeeper);
        statues = GameStatues.Start;

        fontstyle.fontSize = 50;
        fontstyle.normal.textColor = new Color(255, 255, 255);
        fontstyle.alignment = TextAnchor.MiddleCenter;
        //GameObject player = Instantiate(Resources.Load("Prefabs/Player"), Vector3.up, Quaternion.identity) as GameObject;
        //player.transform.rotation = Quaternion.Euler(0, 90, 0);
        //player.transform.position = new Vector3(-5, -3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        switch (statues)
        {
            case GameStatues.Start:
                //UI Main
                break;
            case GameStatues.Pause:
                //UI Pause
                if (GetInput() == KeyCode.P)
                {
                    statues = lastStatus;
                }
                break;
            case GameStatues.Chap1:
                break;
        }

    }
}
