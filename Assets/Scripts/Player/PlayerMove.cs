using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator ani;
    public float speed = 3f;
    public float angleSpeed = 30f;
    static private CubeGestureListener gestureListener;
    static public bool slideChangeWithGestures = true;
    // Start is called before the first frame update
    private string sGestureText = "";
    private GUIStyle titleStyle = new GUIStyle();

    void Start()
    {

        titleStyle.fontSize = 40;
        titleStyle.normal.textColor = new Color(100, 100, 100);
        ani = GetComponent<Animator>();

    }

    public void SetListener ()
    {
        gestureListener = CubeGestureListener.Instance;

        Debug.Log(gestureListener.name);
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        if (slideChangeWithGestures && gestureListener)
        {

            if (gestureListener.LeanLeft)
            {
                h = -1;
            }
            if (gestureListener.LeanRight)
            {
                h = 1;
            }
            if (gestureListener.LeanForward)
            {
                v = 1;
            }
            if (gestureListener.LeanBack)
            {
                v = -1;
            }
     
        }


        if (v != 0 || h != 0)
        {
            AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
            //非攻击动作时可移动
            if (!stateInfo.IsName("Attack01") && !stateInfo.IsName("Attack02"))
            {
                transform.Translate(Vector3.forward * (v * speed + 2) * Time.deltaTime);
                transform.Rotate(Vector3.up, h * angleSpeed * Time.deltaTime);
                transform.Translate(Vector3.right * h * speed * 0.2f * Time.deltaTime);
                this.gameObject.GetComponent<Player>().state.attackState = AttackList.walk.id;
                ani.SetBool("IsMoving", true);
            }
        }
        else
        {
            ani.SetBool("IsMoving", false);
        }
    }
    private void OnGUI()
    {

        GUIStyle fontStyle = new GUIStyle();
        fontStyle.normal.background = null;    //设置背景填充
        fontStyle.normal.textColor = new Color(1, 0, 0);   //设置字体颜色
        fontStyle.fontSize = 80;       //字



        GUI.Label(new Rect(800, 100, 300, 80), sGestureText, titleStyle);

    }
}
