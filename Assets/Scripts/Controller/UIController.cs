using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : Observer
{
    GUIStyle fontstyle = new GUIStyle();                    //GUI
    GameInfo gameInfo = new GameInfo();                     //display game infomation
    private PlayerState playerState = new PlayerState();
    float lengthUnit = SceneController.lengthUnit;
    private void Start()
    {
        fontstyle.fontSize = 50;
        fontstyle.normal.textColor = new Color(255, 255, 255);
        fontstyle.alignment = TextAnchor.MiddleCenter;

    }

    public void SetGame(GameInfo _gameInfo)
    {
        this.gameInfo = _gameInfo;
    }

    public override void ReactionPlayer(PlayerState _playerState)
    {
        playerState = _playerState;
    }

    //useless function
    public override void ReactionEnemy(int enemyNum, int bossNum)
    {

    }

    private void OnGUI()
    {
        if (playerState.isDie)
        {
            GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), "Game Over", fontstyle);
        }
        GUI.Box(new Rect(10, 10, playerState.health * 6, 30), playerState.health + "/100");
        //GUI.Box(new Rect(10, 600, playerState.health * 6, 30), playerState.health + "/100");
    }
}