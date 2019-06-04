using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Observer {
    private PlayerState playerState = new PlayerState();


	// Use this for initialization
	void Start () {
		
	}
    public override void ReactionPlayer(PlayerState _playerState)
    {
        playerState = _playerState;
    }

    //useless function
    public override void ReactionEnemy(int enemyNum, int bossNum)
    {

    }

    // Update is called once per frame
    void Update () {
		
	}


}