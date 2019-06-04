using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    GUIStyle titleStyle = new GUIStyle();               //title GUI style
    GUIStyle tipStyle = new GUIStyle();                 //tips GUI style
    float lengthUnit = SceneController.lengthUnit;
    public static int GameLevel;
    bool jump = false;
    string[] GameDifficult = new string[] { "Paradise", "Easy", "Difficult", "Hell"};
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome start layer");
        {
            titleStyle.fontSize = (int)lengthUnit * 10;
            titleStyle.normal.textColor = new Color(100, 100, 100);
            titleStyle.alignment = TextAnchor.MiddleCenter;
        }
        {
            tipStyle.fontSize = (int)lengthUnit * 4;
            tipStyle.normal.textColor = new Color(100, 200, 150);
            tipStyle.alignment = TextAnchor.MiddleCenter;
        }
        GameLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width * 0.5f - (lengthUnit * 10), Screen.height * 0.1f, lengthUnit * 20, lengthUnit * 5),
            "Choose the Difficult", titleStyle);
        GUI.Label(new Rect(Screen.width * 0.5f - (lengthUnit * 10), Screen.height * 0.1f + (lengthUnit * 10), lengthUnit * 20, lengthUnit * 5),
            "Current: " + GameDifficult[GameLevel], titleStyle);
        for (int i = 0; i < 4; i++)
        {
            if (GUI.Button(new Rect(Screen.width * 0.5f - (lengthUnit * 15 * (2 - i)), Screen.height * 0.4f, lengthUnit * 15, lengthUnit * 5), GameDifficult[i]))
            {
                GameLevel = i;
            }
        }
        if (GUI.Button(new Rect(Screen.width * 0.2f - (lengthUnit * 5), Screen.height * 0.8f, lengthUnit * 10, lengthUnit * 5), "Start/S", titleStyle)
            || SceneController.GetInput() == KeyCode.S)
        {
            if (!jump)
            {
                jump = !jump;
                GameObject.Find("myData").GetComponent<SceneController>().StartGame();
            }
        }
        if (GUI.Button(new Rect(Screen.width * 0.5f - (lengthUnit * 5), Screen.height * 0.8f, lengthUnit * 10, lengthUnit * 5), "Help/H", titleStyle)
            || SceneController.GetInput() == KeyCode.H)
        {
            if (!jump)
            {
                jump = !jump;
                GameObject.Find("myData").GetComponent<SceneController>().NextSection();
                return ;
            }
        }
        if (GUI.Button(new Rect(Screen.width * 0.8f - (lengthUnit * 5), Screen.height * 0.8f, lengthUnit * 10, lengthUnit * 5), "Quit/Q", titleStyle)
            || SceneController.GetInput() == KeyCode.Q)
        {
            Application.Quit();
        }
    }
}
