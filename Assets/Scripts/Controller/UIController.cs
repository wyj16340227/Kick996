using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : Observer
{
    GUIStyle fontstyle = new GUIStyle();                //GUI
    GameStatues gameStatues;
    private bool gameOver;
    private void Start()
    {
        fontstyle.fontSize = 50;
        fontstyle.normal.textColor = new Color(255, 255, 255);
        fontstyle.alignment = TextAnchor.MiddleCenter;
    }

    public void SetGame(GameStatues _gameStatus)
    {
        this.gameStatues = _gameStatus;
    }

    public override void Reaction(PlayerState playerState)
    {
        gameOver = playerState.isDie;
    }

    private void OnGUI()
    {
        if (gameOver)
        {
            GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), "Game Over", fontstyle);
        }

    }
}