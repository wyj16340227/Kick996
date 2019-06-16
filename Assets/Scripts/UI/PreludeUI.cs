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

        intro = new string[] {"这是一个勇者的故事",
        "他从修道院出发，孑然一身",
        "踏上了挑战魔王的道路",
        "从这开始进入他的故事"};
        {
            titleStyle.fontSize = (int)lengthUnit * 10;
			titleStyle.normal.textColor = Color.white;
            titleStyle.alignment = TextAnchor.MiddleCenter;
        }
        {
            tipStyle.fontSize = (int)lengthUnit * 4;
            tipStyle.normal.textColor = new Color(192, 192, 192);
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
        if (GUI.Button(new Rect(Screen.width * 0.7f, Screen.height * 0.8f, lengthUnit * 20, lengthUnit * 5),
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
        GUI.Box(new Rect(Screen.width * 0.5f - (lengthUnit * 15), Screen.height * 0.5f, lengthUnit * 30, lengthUnit * 5), 
            intro[(int)(currentTime / secondPerSentence)], titleStyle);                     //story
    }
}
