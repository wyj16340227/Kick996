using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpUI : MonoBehaviour
{
    string[] tips;
    string[] info;
    int currentClick;
    // Start is called before the first frame update
    void Start()
    {
        tips = new string[] {
            "Move",
            "Attack",
            "Defense"
        };
        info = new string[]
        {
            "using wasd",
            "using ",
            "using "
        };
        currentClick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GUI.Label(new Rect(0, 0, 100, 20), "Tips");
        for (int i = 0; i < 3; i++)
        {
            if (GUI.Button(new Rect(100 + 50 * i, 100, 50, 50), tips[i]))
            {
                currentClick = i;
            }
        }
        GUI.Label(new Rect(200, 200, 100, 50), info[currentClick]);
        if (GUI.Button(new Rect(300, 100, 50, 50), "Return"))
        {
#pragma warning disable CS0618 // 类型或成员已过时
            Application.LoadLevel("start");
#pragma warning restore CS0618 // 类型或成员已过时
        }
        if (GUI.Button(new Rect(350, 100, 50, 50), "Quit"))
        {
            
        }
    }
}
