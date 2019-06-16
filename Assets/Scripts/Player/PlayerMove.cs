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
    void Start()
    {
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

        //if (slideChangeWithGestures && gestureListener)
        //{

        //    if (gestureListener.IsLeanLeft())
        //    {
        //        h = -1;
        //    }
        //    if (gestureListener.IsLeanRight())
        //    {
        //        h = 1;
        //    }
        //    if (gestureListener.IsTpose())
        //    {
        //        v = 1;
        //    }
        
        //}
       


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
}
