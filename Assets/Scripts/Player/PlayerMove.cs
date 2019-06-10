using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator ani;
    public float speed = 2f;
    public float angleSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        if (v !=0 || h != 0)
        {
            AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
            //非攻击动作时可移动
            if (!stateInfo.IsName("Attack01") && !stateInfo.IsName("Attack02"))
            {
                transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
                transform.Translate(Vector3.right * h * speed * Time.deltaTime);
                transform.Rotate(Vector3.up, h * angleSpeed * Time.deltaTime);
                ani.SetBool("IsMoving", true);
            }
        }
        else
        {
            ani.SetBool("IsMoving", false);
        }
    }
}
