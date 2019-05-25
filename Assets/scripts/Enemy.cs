using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Observer {
    private PlayerState playerState;


	// Use this for initialization
	void Start () {
		
	}
    public override void Reaction(PlayerState _playerState)
    {
        playerState = _playerState;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
