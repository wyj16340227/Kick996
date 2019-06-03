using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatues
{
    Pause,
    GameOver,
    Win,
    Help,
    Running
}

public class GameInfo
{
    public int chapter { get; set; }                    //chapter
    public int section { get; set; }                    //section
}

public class SceneController : Observer
{
    public GameInfo gameInfo = new GameInfo();
    public GameStatues status;                          //GameStatus, First in Start
    public int[][] enemyNum = new int[4][];             //enemy number of each section
    public string[][] sectionName = new string[4][];    //section name of each chapter
    public int[] secNumPerChap;                         //section number of each chapter
    public int restEnemy;
    public UIController UI;
    public Model model;

    public static float lengthUnit = Screen.height / 73;       //10

    //statric function, get input from keyboard or kinect
    static public KeyCode GetInput()
    {
        if (Input.anyKeyDown)
        {
            return Event.current.keyCode;
        }
        else
        {
            return KeyCode.L;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("create a scene controller");
        DontDestroyOnLoad(this);
        gameInfo.chapter = 0;
        gameInfo.section = 0;
        status = GameStatues.Help;
        enemyNum[0] = new int[] { 0, 0, 0 };
        enemyNum[1] = new int[] { 6, 6, 6 };
        {
            secNumPerChap = new int[] { 3, 6 };
        }
        {
            sectionName[0] = new string[] { "prelude", "start", "help" };
            sectionName[1] = new string[] { "chapaa" };
        }
        UI = gameObject.AddComponent<UIController>() as UIController;
        UI.SetGame(gameInfo);
        model = gameObject.AddComponent<Model>() as Model;

        //diskmanager.GetScore(scoreKeeper);


        //GameObject player = Instantiate(Resources.Load("Prefabs/Player"), Vector3.up, Quaternion.identity) as GameObject;
        //player.transform.rotation = Quaternion.Euler(0, 90, 0);
        //player.transform.position = new Vector3(-5, -3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        gameInfo.chapter = 1;
        gameInfo.section = 0;
        status = GameStatues.Running;
#pragma warning disable CS0618 // 类型或成员已过时
        Application.LoadLevel(sectionName[gameInfo.chapter][gameInfo.section]);
#pragma warning restore CS0618 // 类型或成员已过时
    }

    public void NextSection()
    {
        Debug.Log("Perepare to turn to next section");
        gameInfo.section++;
        if (gameInfo.section == secNumPerChap[gameInfo.chapter])
        {
            gameInfo.section = 0;
            gameInfo.chapter++;
        }
        if(gameInfo.chapter == 5)
        {
            status = GameStatues.Win;
        }
        Debug.Log(sectionName[gameInfo.chapter][gameInfo.section]);
#pragma warning disable CS0618 // 类型或成员已过时
        Application.LoadLevel(sectionName[gameInfo.chapter][gameInfo.section]);
#pragma warning restore CS0618 // 类型或成员已过时
    }

    public void TurnToSection(int _chapter, int _section)
    {
        Debug.Log("Perepare to turn");
        gameInfo.chapter = _chapter;
        gameInfo.section = _section;
        Debug.Log(sectionName[gameInfo.chapter][gameInfo.section]);
#pragma warning disable CS0618 // 类型或成员已过时
        Application.LoadLevel(sectionName[gameInfo.chapter][gameInfo.section]);
#pragma warning restore CS0618 // 类型或成员已过时
    }

    public override void Reaction (PlayerState playerState)
    {
        if (playerState.isDie)
        {
            status = GameStatues.GameOver;
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