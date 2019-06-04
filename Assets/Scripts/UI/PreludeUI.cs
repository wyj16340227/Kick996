using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreludeUI : MonoBehaviour
{
    GUIStyle titleStyle = new GUIStyle();               //title GUI style
    GUIStyle tipStyle = new GUIStyle();                 //tips GUI style
    float lengthUnit = SceneController.lengthUnit;
    string[] intro;
    float currentTime;                                  //remark current time
    int secondPerSentence = 2;                          //sentence time
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome prelude layer");
        intro = new string[] {"this is a old story",
        "good good study",
        "day day up",
        "Welcome"};
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
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime / secondPerSentence < intro.Length - 1)
        {
            currentTime += Time.deltaTime;
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * 0.7f, Screen.height * 0.8f, lengthUnit * 2, lengthUnit * 5),
            "Skip/S", titleStyle) || SceneController.GetInput() == KeyCode.S)
        {
            if (!jump)
            {
                jump = !jump;
                Debug.Log("Turn to Start layer");
                GameObject.Find("myData").GetComponent<SceneController>().NextSection();
                return;
            }
        }
        GUI.Label(new Rect(Screen.width * 0.5f - (lengthUnit * 15), Screen.height * 0.5f, lengthUnit * 30, lengthUnit * 5), 
            intro[(int)(currentTime / secondPerSentence)], titleStyle);                     //story
    }
}
