using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public enum GameStatues
{
    Pause,
    GameOver,
    Win,
    Help,
    Running,
    Loading
}

public class GameInfo
{
    public int chapter { get; set; }                    //chapter
    public int section { get; set; }                    //section
}

public class Bound
{
    static public Vector3 leftBound = new Vector3(8, 0, 0);
    static public Vector3 rightBound = new Vector3(-8, 0, 0);
}

public class SceneController : Observer
{
    public GameInfo gameInfo = new GameInfo();
    public GameStatues status;                          //GameStatus, First in Start
    public int[][] enemyNum = new int[4][];             //enemy number of each section
    public int[][] maxEnemyNum = new int[4][];          //Max num of enemy in scene
    public string[][] sectionName = new string[4][];    //section name of each chapter
    public int[] secNumPerChap;                         //section number of each chapter
    public int restEnemy;
    public UIController UI;
    public Model model;
    public float loadingTime;

    public static float lengthUnit = Screen.height / 73;       //10

    public override void ReactionPlayer(PlayerState playerState)
    {
        if (playerState.isDie)
        {
            status = GameStatues.GameOver;
        }
    }

    public override void ReactionEnemy(int enemyNum, int bossNum)
    {
        if (enemyNum < maxEnemyNum[gameInfo.chapter][gameInfo.section])
        {
            model.GetAnEnemy();
        }
    }

    //statric function, get input from keyboard or kinect
    static public KeyCode GetInput()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            return KeyCode.S;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            return KeyCode.R;
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            return KeyCode.J;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            return KeyCode.K;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            return KeyCode.L;
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            return KeyCode.H;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            return KeyCode.Q;
        }
        else
        {
            return KeyCode.None;
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
        {
            enemyNum[0] = new int[] { 0, 0, 0 };
            enemyNum[1] = new int[] { 6, 6, 6 };

        }
        {
            maxEnemyNum[0] = new int[] { 0, 0, 0 };
            maxEnemyNum[1] = new int[] { 3, 3, 3 };
        }
        {
            secNumPerChap = new int[] { 3, 6 };
        }
        {
            sectionName[0] = new string[] { "prelude", "start", "help" };
            sectionName[1] = new string[] { "chapaa" };
        }
        model = gameObject.AddComponent<Model>() as Model;
        UI = gameObject.AddComponent<UIController>() as UIController;
        UI.SetGame(gameInfo);
        //model.getObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case GameStatues.Loading:
                if (loadingTime > 0)
                {
                    loadingTime -= Time.deltaTime;
                }
                else
                {
                    status = GameStatues.Running;
                    model.NewScene(gameInfo);
                }
                break;
            case GameStatues.Running:

                break;
            case GameStatues.GameOver:

                break;
            default:
                //Console.WriteLine("无效的成绩");
                break;
        }
    }

    public void StartGame()
    {
        model.getPlayer().GetComponent<Player>().Attach(UI);
        gameInfo.chapter = 1;
        gameInfo.section = 0;
        status = GameStatues.Loading;
        loadingTime = 1;
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
}