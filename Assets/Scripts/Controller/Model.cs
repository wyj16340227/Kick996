using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {
    private Subject sub;
    private GameObject player;
    private Observer obs;
    private EnemyFactory enemyFac;
    // Use this for initialization
    void Start () {
		
	}

    
	
	// Update is called once per frame
	void Update () {
		
	}

    //add to the observer
    public void getObserver(SceneController obs)
    {
        Subject tempSub = player.GetComponent<Player>();
        tempSub.Attach(obs);
    }

    public GameObject getPlayer()
    {
        return player;
    }
}
