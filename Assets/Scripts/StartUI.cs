using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    GUIStyle fontstyle = new GUIStyle();                //GUI
    public static int GameLevel;
    string[] GameDifficult = new string[] { "Paradise", "Easy", "Difficult", "Hail"};
    // Start is called before the first frame update
    void Start()
    {
        fontstyle.fontSize = 50;
        fontstyle.normal.textColor = new Color(255, 255, 255);
        fontstyle.alignment = TextAnchor.MiddleCenter;
        GameLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 20), "Choose the Difficult");
        GUI.Label(new Rect(0, 100, 100, 20), "Current: " + GameDifficult[GameLevel]);
        for (int i = 0; i < 4; i++)
        {
            if (GUI.Button(new Rect(100 + 50 * i, 100, 50, 50), GameDifficult[i]))
            {
                GameLevel = i;
            }
        }
        if (GUI.Button(new Rect(100, 200, 50, 50), "Start"))
        {
#pragma warning disable CS0618 // 类型或成员已过时
            Application.LoadLevel("chapaa");
#pragma warning restore CS0618 // 类型或成员已过时
        }
        if (GUI.Button(new Rect(200, 200, 50, 50), "Help"))
        {
#pragma warning disable CS0618 // 类型或成员已过时
            Application.LoadLevel("help");
#pragma warning restore CS0618 // 类型或成员已过时
        }
        if (GUI.Button(new Rect(300, 200, 50, 50), "Quit"))
        {
            
        }
    }
}
