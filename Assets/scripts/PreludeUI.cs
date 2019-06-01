using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreludeUI : MonoBehaviour
{
    GUIStyle fontstyle = new GUIStyle();                //GUI
    string[] intro;
    float currentTime;                                  //remark current time
    int secondPerSentences = 1;                         //sentence time

    // Start is called before the first frame update
    void Start()
    {
        intro = new string[] {"this is a old story",
        "good good study",
        "day day up",
        "Welcome"};
        currentTime = 0;
        fontstyle.fontSize = 50;
        fontstyle.normal.textColor = new Color(255, 255, 255);
        fontstyle.alignment = TextAnchor.MiddleCenter;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(intro.Length);
        Debug.Log(currentTime);
        if (currentTime / secondPerSentences < intro.Length - 1)
        {
            currentTime += Time.deltaTime;
        }
    }

    private void OnGUI()
    {

        GUI.TextArea(new Rect(0, 0, 200, 200), "Press key S to skip the prelude", fontstyle);
        if (SceneController.GetInput() == KeyCode.S)
        {
#pragma warning disable CS0618 // 类型或成员已过时
            Application.LoadLevel("start");
#pragma warning restore CS0618 // 类型或成员已过时
        }
        GUI.TextArea(new Rect(0, 200, 200, 200), intro[(int)currentTime], fontstyle);                   //story
    }
}
