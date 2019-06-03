using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {
    private GameObject player;
    private EnemyFactory enemyFac;
    private int enemyType;
    // Use this for initialization
    void Start () {
        enemyFac = gameObject.AddComponent<EnemyFactory>() as EnemyFactory;
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
