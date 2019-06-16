using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : Subject
{
    private static List<GameObject> used = new List<GameObject>();
    private static List<GameObject> free = new List<GameObject>();
    private string prefabPre;
    private string[] prefabName;
    private string prefabPath;
    private int enemyNum = 0;
    private int bossNum = 0;
    private int count = 0;
    public Player player;

    protected List<Observer> obs = new List<Observer>();   //所有observer

    public override void Attach(Observer o)
    {
        Debug.Log("get one " + o.name);
        obs.Add(o);
    }

    public override void Detach(Observer o)
    {
        obs.Remove(o);
    }

    public override void NotifyPlayer(PlayerState playerState)
    {

    }

    //useless funciton
    public override void NotifyEnemy(int enemyNum, int bossNum)
    {
        foreach (Observer o in obs)
        {
            o.ReactionEnemy(enemyNum, bossNum);
        }
    }

    void Start()
    {
        prefabPre = "Prefabs/";
        prefabName = new string[] {
            "",
            "Enemy1",
            "Enemy2",
            "Enemy3"
        };
    }

    public void ResetEnemy(int chapter)
    {
        prefabPath = prefabPre + prefabName[chapter];
        while (used.Count != 0)
        {
            used.RemoveAt(0);
        }
        while (free.Count != 0)
        {
            free.RemoveAt(0);
        }
        enemyNum = 0;
        bossNum = 0;
        this.NotifyEnemy(enemyNum, bossNum);
    }

    public GameObject GetEnemy()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }
        Debug.Log("Factory Get An Enemy");
        if (free.Count != 0)
        {
            used.Add(free[0]);
            free.RemoveAt(0);
            used[used.Count - 1].SetActive(true);
        }
        else
        {
            GameObject tempEnemy = Instantiate(Resources.Load("Prefabs/Enemy1"), Vector3.up, Quaternion.identity) as GameObject;
            tempEnemy.GetComponent<Enemy>().FindMother(this.GetComponent<EnemyFactory>());
            tempEnemy.name = "EnemyN" + count;
            count++;
            tempEnemy.transform.position = new Vector3(Random.Range(-80, 80), 0, Random.Range(-80, 80));
            tempEnemy.transform.localEulerAngles = new Vector3(0, 0, 0);
            used.Add(tempEnemy);
            tempEnemy.SetActive(true);
            player.Attach(tempEnemy.GetComponent<Enemy>());
        }
        enemyNum++;
        this.NotifyEnemy(enemyNum, bossNum);


        string t = "Factory: ";
        foreach (GameObject e in used)
        {
            t += e.gameObject.name;
        }
        Debug.Log(t);

        return used[used.Count - 1];
    }

    public void FreeEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        used.Remove(enemy);
        free.Add(enemy);
    }
}
