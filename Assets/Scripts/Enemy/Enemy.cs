﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class EnemyState
{
    public int level { get; set; }
    public float health { get; set; }
    public int damage { get; set; }
    public int defense { get; set; }
    public float CD { get; set; }
    public float chasingDis { get; set; }
    public float speed { get; set; }
}

public class Enemy : Observer {
    private PlayerState playerState = new PlayerState();
    public EnemyState states = new EnemyState();
    public EnemyFactory mother;
    public UnityEngine.UI.Image lifeBar;
    // Use this for initialization


    //public Texture2D blood;
    // Use this for initialization
    void Start () {
        states.level = 1;
        states.health = 100;
        states.damage = 1;
        states.defense = 1;
        states.chasingDis = 30;
        states.speed = 2f;
        states.CD = 0;
        Canvas temp = transform.Find("Canvas").GetComponent<Canvas>();
        
    //HealthSlider = temp.transform.GetChild(0).GetComponent<Slider>();
    //HealthSlider = temp.GetComponentInChildren<Slider>();
}

    public void GetDamage(float amount)
    {
        //Debug.Log("Enemy Get Attack " + amount);
        AnimatorStateInfo stateInfo = GameObject.Find("Player").GetComponent<Player>().ani.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Stand") || stateInfo.IsName("Walk")){
            return;
        }
        if (amount < 0)
        {
            return;
        }
        states.health -= amount;
        lifeBar.fillAmount -= (amount / 100);
        if (states.health < 0)
        {
            //Debug.Log("Enemy Die");
            mother.FreeEnemy(this.gameObject);
        }
    }

    public void FindMother(EnemyFactory _mother)
    {
        mother = _mother;
    }

    public override void ReactionPlayer(PlayerState _playerState)
    {
        //Debug.Log(this.gameObject.name + "get message");
        playerState = _playerState;
    }

    //useless function
    public override void ReactionEnemy(int enemyNum, int bossNum)
    {

    }

    void turn()
    {
        transform.Rotate(0, 90, 0);
    }

    void OnCollisionEnter(Collision e)
    {
        //Debug.Log(this.name + " On Collision with " + e.gameObject.name);
        //collision not the player
        //if (e.gameObject.CompareTag("Wall") || e.gameObject.CompareTag("Enemy"))
        if (!e.gameObject.CompareTag("Player"))
        {
            turn();
            return;
        }
        int temp = playerState.attackState;
        int playerKill = states.damage - playerState.defense * Player.attackList[temp].protect;
        if (playerKill > 0)
        {
            e.gameObject.GetComponent<Player>().GetAttack(playerKill);
            turn();
            states.CD = 2f;
        }
    }

    public float GetDefense()
    {
        return states.defense;
    }

    // Update is called once per frame
    void Update () {

        transform.Translate(0, 0, Time.deltaTime * states.speed);
        float distance = Vector3.Distance(playerState.position, transform.position);
        int temp = playerState.attackState;
        //go
        if (states.CD > 0)
        {
            states.CD -= Time.deltaTime;
            return;
        }
        ////under attack range and take hurt
        //if (distance < Player.attackList[temp].range)
        //{
        //    float hurt = Player.attackList[temp].damage * playerState.damage - states.defense;
        //    if (hurt < 0)
        //    {
        //        return;
        //    }
        //    this.GetDamage(hurt);
        //    states.CD = playerState.time;
        //    return;
        //}
        if (distance < states.chasingDis)
        {
            //Debug.Log(this.gameObject.name + "Start to chasing player");
            transform.LookAt(playerState.position);
        }
    }

    //void OnGUI()
    //{
    //    Vector3 headPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2.5f);   //将该物体头上的一点转化为屏幕坐标；  
    //    GUI.DrawTexture(new Rect(headPos.x - 15, Screen.height - headPos.y, 20 * states.health / 100, 3), blood);   //（headPos.x-15,Screen.Height-headPos.y）
    //}
}