using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack
{
    public int id { get; set; }
    public int damage { get; set; }
    public int range { get; set; }
    public int protect { get; set; }
    public float attackTime { get; set; }
    public playerAttack (int _id, int _damage, int _range, int _protect, float _attackTime)
    {
        id = _id;
        damage = _damage;
        range = _range;
        protect = _protect;
        attackTime = _attackTime;
    }
}

public static class AttackList // static 不是必须
{
    //此处可添加不同的攻击方式
    public static playerAttack stand = new playerAttack(0, 10, -1, 0, 0);            //静止，默认
    public static playerAttack walk = new playerAttack(0, 10, -1, 0, 0);             //走路
    public static playerAttack attack1 = new playerAttack(1, 10, 1, 0, 2);          //攻击，J
    public static playerAttack big = new playerAttack(1, 10, 20, 0, 1f);             //大招，K
    public static playerAttack defense = new playerAttack(0, 0, -1, 100, 2f);       //防御，L
}

public class PlayerState
{
    public int level { get; set; }
    public float health { get; set; }
    public bool isDie { get; set; }
    public Vector3 position { get; set; }
    public int attackState { get; set; }
    public int damage { get; set; }
    public int defense { get; set; }
    public float time { get; set; }
    public float speed { get; set; }
}

public class Player : Subject
{
    public Animator ani;
    public static playerAttack[] attackList = new playerAttack[5];
    public PlayerState state = new PlayerState();
    public static Dictionary<int, string> stateDic = new Dictionary<int, string>();
    // Use this for initialization
    void Start ()
    {
        {
            attackList[0] = AttackList.stand;
            attackList[1] = AttackList.walk;
            attackList[2] = AttackList.attack1;
            attackList[3] = AttackList.big;
            attackList[4] = AttackList.defense;
        }
        {
            stateDic.Add(0, "Stand");
            stateDic.Add(1, "Walk");
            stateDic.Add(2, "Attack01");
            stateDic.Add(3, "Attack02");
        }

        DontDestroyOnLoad(this);
        state.level = 1;                        //等级
        state.health = 100;                     //生命值
        state.isDie = false;                    //初始活着
        state.attackState = AttackList.stand.id;//初始站立
        state.damage = 1;                       //攻击力
        state.defense = 1;                      //护甲
        state.time = 1;                         //技能时间
        ani = GetComponent<Animator>();
	}

    protected List<Observer> obs = new List<Observer>();   //所有observer

    public override void Attach(Observer o)
    {
        Debug.Log("get one " + o.name);
        obs.Add(o);
        Debug.Log(obs.Count + " obs");
        string t = "enemy: ";
        foreach(Observer ob in obs)
        {
            t += ob.gameObject.name;
        }
        Debug.Log(t);
    }

    public override void Detach(Observer o)
    {
        obs.Remove(o);
    }

    public override void NotifyPlayer(PlayerState playerState)
    {
        foreach (Observer o in obs)
        {
            //Debug.Log("told " + o.gameObject.name);
            o.ReactionPlayer(playerState);
        }
    }

    //useless funciton
    public override void NotifyEnemy(int enemyNum, int bossNum)
    {

    }


    // Update is called once per frame
    void Update ()
    {
        state.position = transform.position;
        NotifyPlayer(state);
        //transform.Rotate(Vector3.up, Input.GetAxisRaw("Horizontal") * Time.deltaTime);
        AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
        //攻击动作的时候不能移动
        if (stateInfo.IsName(stateDic[2]) || stateInfo.IsName(stateDic[3]))
        {
            //攻击动作结束
            ani.SetBool("Attack1", false);
            ani.SetBool("Attack2", false);
            return;
        }
        KeyCode kc = SceneController.GetInput();

        switch (kc)
        {
            case KeyCode.J:
                state.attackState = AttackList.attack1.id;
                ani.SetBool("Attack1", true);
                ani.SetBool("IsMoving", false);
                break;
            case KeyCode.K:
                state.attackState = AttackList.big.id;
                //this.GetComponent<MeshRenderer>().material.color = Color.blue;
                ani.SetBool("Attack2", true);
                ani.SetBool("IsMoving", false);
                break;
            case KeyCode.L:
                state.attackState = AttackList.defense.id;
                //this.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            case KeyCode.Q:
                //this.GetComponent<MeshRenderer>().material.color = Color.green;
                transform.Translate(Vector3.forward * 5);
                break;
            case KeyCode.R:
                transform.Rotate(Vector3.up, 180);
                break;
            default:
                break;
        }
    }

    public void GetAttack (float amount)
    {
        Debug.Log("Player Get Attack");
        if (amount < 0)
        {
            return;
        }
        state.health -= amount;
        if (state.health <= 0 && !state.isDie)
        {
            this.Death();
        }
    }

    public void Death ()
    {
        this.state.isDie = true;
        this.ani.SetBool("IsDie", true);
    }

    //void OnCollisionEnter(Collision e)
    //{
    //    Debug.Log("Player On Collision with " +  e.gameObject.name);
    //    if (e.gameObject.CompareTag("Enemy"))
    //    {
    //        int temp = state.attackState;
    //        float enemyKill = state.damage * attackList[temp].damage - e.gameObject.GetComponent<Enemy>().GetDefense();
    //        if (enemyKill > 0)
    //        {
    //            e.gameObject.GetComponent<Enemy>().GetDamage(enemyKill);
    //        }
    //    }
    //}
}
