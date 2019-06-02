using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private static List<GameObject> used = new List<GameObject>();
    private static List<GameObject> free = new List<GameObject>();
    private string prefabPre;
    private string[] prefabName;
    private string prefabPath;

    void Start()
    {
        prefabPre = "Prefabs/";
        prefabName = new string[] {
            "",
            "enemy1",
            "enemy2",
            "enemy3"
        };
    }

    public void ResetEnemy(int chapter)
    {
        prefabPath = prefabPre + prefabName[chapter];
        used.Clear();
        free.Clear();
    }

    public GameObject GetEnemy()
    {
        if (free.Count != 0)
        {
            used.Add(free[0]);
            free.RemoveAt(0);
            used[used.Count - 1].SetActive(true);
        }
        else
        {
            GameObject tempEnemy = Instantiate(Resources.Load(prefabPath), Vector3.up, Quaternion.identity) as GameObject;
            used.Add(tempEnemy);
            used[used.Count - 1].SetActive(true);
        }
        return used[used.Count - 1];
    }

    public void FreeEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        used.Remove(enemy);
        free.Add(enemy);
    }
}
