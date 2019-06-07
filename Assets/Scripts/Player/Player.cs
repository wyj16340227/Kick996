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
    public static playerAttack stand = new playerAttack(0, 0, -1, 0, 0);             //静止，默认
    public static playerAttack attack1 = new playerAttack(1, 1, 1, 0, 2);        //攻击，J
    public static playerAttack big = new playerAttack(1, 1, 1, 0, 1f);            //大招，K
    public static playerAttack defense = new playerAttack(0, 0, -1, 100, 2f);        //防御，L
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
    public static playerAttack[] attackList = new playerAttack[5];
    private PlayerState state = new PlayerState();
	// Use this for initialization
	void Start ()
    {
        {
            attackList[0] = AttackList.stand;
            attackList[1] = AttackList.attack1;
            attackList[2] = AttackList.big;
            attackList[3] = AttackList.defense;
        }

        DontDestroyOnLoad(this);
        state.level = 1;                        //等级
        state.health = 100;                     //生命值
        state.isDie = false;                    //初始活着
        state.attackState = AttackList.stand.id;//初始站立
        state.damage = 1;                       //攻击力
        state.defense = 1;                      //护甲
        state.time = 1;                         //技能时间
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
            Debug.Log("told " + o.gameObject.name);
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
        if (state.attackState != AttackList.stand.id)
        {
            if (state.time > 0)
            {
                state.time -= Time.deltaTime;
                return;
            }
            else
            {
                state.attackState = AttackList.stand.id;
                this.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
        KeyCode kc = SceneController.GetInput();
        switch (kc)
        {
            case KeyCode.J:
                state.attackState = AttackList.attack1.id;
                this.GetComponent<MeshRenderer>().material.color = Color.black;
                state.time = AttackList.attack1.attackTime;
                break;
            case KeyCode.K:
                state.attackState = AttackList.big.id;
                this.GetComponent<MeshRenderer>().material.color = Color.blue;
                state.time = AttackList.big.attackTime;
                break;
            case KeyCode.L:
                state.attackState = AttackList.defense.id;
                this.GetComponent<MeshRenderer>().material.color = Color.green;
                state.time = AttackList.defense.attackTime;
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

    }

    void OnCollisionEnter(Collision e)
    {
        Debug.Log("Player On Collision with " +  e.gameObject.name);
        if (e.gameObject.CompareTag("Enemy"))
        {
            int temp = state.attackState;
            float enemyKill = state.damage * attackList[temp].damage - e.gameObject.GetComponent<Enemy>().GetDefense();
            if (enemyKill > 0)
            {
                e.gameObject.GetComponent<Enemy>().GetDamage(enemyKill);
            }
        }
    }

    //public void TakeDamage(int amount)
    //{
    //    damaged = true;

    //    currentHealth -= amount;

    //    healthSlider.value = currentHealth;

    //    playerAudio.Play();

    //    if (currentHealth <= 0 && !isDead)
    //    {
    //        Death();
    //    }
    //}
}
