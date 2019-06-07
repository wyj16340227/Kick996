using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    private int count = 0;
    private Subject sub;
    private GameObject player;
    private EnemyFactory enemyFac;
    private int enemyType;
    // Use this for initialization
    void Start ()
    {
        Debug.Log("Create a Model");
        player = Instantiate(Resources.Load("Prefabs/Player"), Vector3.up, Quaternion.identity) as GameObject;
        player.transform.position = new Vector3(0, 11, 0);
        enemyFac = gameObject.AddComponent<EnemyFactory>() as EnemyFactory;
        enemyFac.GetComponent<EnemyFactory>().Attach(GameObject.Find("myData").GetComponent<SceneController>());
        sub = player.GetComponent<Player>();
        player.GetComponent<Player>().Attach(GameObject.Find("myData").GetComponent<SceneController>());
	}

    public void NewScene(GameInfo gameInfo)
    {
        player.GetComponent<Rigidbody>().useGravity = true;
        player.transform.position = Bound.leftBound;
        enemyFac.ResetEnemy(gameInfo.chapter);
    }

    public GameObject getPlayer()
    {
        return player;
    }

    public void GetAnEnemy ()
    {
        Debug.Log("Model Get Enemy");
        GameObject tempobj = enemyFac.GetEnemy();
        tempobj.name = "EnemyN" + count;
        count++;
        tempobj.GetComponent<Enemy>().FindMother(enemyFac);
        player.GetComponent<Player>().Attach(tempobj.GetComponent<Enemy>());
    }

    //
    public void SetPlayerLoc(bool pos)
    {
        if (pos)
        {
            player.transform.position = new Vector3(3, 0, 0);
        }
        else
        {
            player.transform.position = new Vector3(-3, 0, 0);
        }
    }
}
