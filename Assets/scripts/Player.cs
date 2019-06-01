using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack
{
    public int id { get; set; }
    public int damage { get; set; }
    public int range { get; set; }
    public int protect { get; set; }
    public playerAttack (int _id, int _damage, int _range, int _protect)
    {
        id = _id;
        damage = _damage;
        range = _range;
        protect = _protect;
    }
}

public static class attackList // static 不是必须
{
    //此处可添加不同的攻击方式
    public static playerAttack stand = new playerAttack(0, 0, 0, 0);         //站立不动
    public static playerAttack attack1 = new playerAttack(1, 1, 1, 0);

    public static playerAttack defense = new playerAttack(0, 0, 0, 100);        //防御
}

public class PlayerState
{
    public int life { get; set; }
    public Vector3 position { get; set; }
    public playerAttack attackState { get; set; }
    public int damage { get; set; }
    public int defense { get; set; }
    
}

public abstract class Observer : MonoBehaviour
{
    public abstract void Reaction(PlayerState playertate);

}

public abstract class Subject : MonoBehaviour
{
    List<Observer> m_Observers = new List<Observer>();

    public abstract void Attach(Observer listener);

    public abstract void Detach(Observer theObserver);

    public abstract void Notify(PlayerState playertate);
}

public class Player : Subject
{
    private PlayerState state;
	// Use this for initialization
	void Start () {
        state.life = 100;                       //生命值
        state.attackState = attackList.stand;   //初始站立
        state.damage = 1;                       //攻击力
        state.defense = 1;                      //护甲
        //state.position =                      //初始位置
	}

    protected List<Observer> obs = new List<Observer>();   //所有observer

    public override void Attach(Observer o)
    {
        obs.Add(o);
    }

    public override void Detach(Observer o)
    {
        obs.Remove(o);
    }

    public override void Notify(PlayerState playerState)
    {
        foreach (Observer o in obs)
        {
            o.Reaction(playerState);
        }
    }

    // Update is called once per frame
    void Update () {
        Notify(state);
    }

    public void GetAttack (int amount)
    {
        state.life -= amount;   
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
