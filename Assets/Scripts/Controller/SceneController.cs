using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatues
{
    Pause,
    GameOver,
    Running,
    Help
}

public class GameInfo
{
    public int chapter { get; set; }                    //chapter
    public int section { get; set; }                    //section

}

public class SceneController : Observer
{
    public GameStatues statues;                         //GameStatus, First in Start
    public GameStatues lastStatus;                      //Last Status, to remain the status before pause

    public GameInfo gameInfo;

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
        //myData = gameObject.AddComponent<Data>() as Data;
        //diskmanager.GetScore(scoreKeeper);


        //GameObject player = Instantiate(Resources.Load("Prefabs/Player"), Vector3.up, Quaternion.identity) as GameObject;
        //player.transform.rotation = Quaternion.Euler(0, 90, 0);
        //player.transform.position = new Vector3(-5, -3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Reaction (PlayerState playerState)
    {
        if (playerState.isDie)
        {
            statues = GameStatues.GameOver;
        }
    }


    //private void OnGUI()
    //{
    //    switch (statues)
    //    {
    //        case GameStatues.:
    //            //UI Main
    //            break;
    //        case GameStatues.Pause:
    //            //UI Pause
    //            if (GetInput() == KeyCode.P)
    //            {
    //                statues = lastStatus;
    //            }
    //            break;
    //        case GameStatues.Chap1:
    //            break;
    //    }

    //}
}