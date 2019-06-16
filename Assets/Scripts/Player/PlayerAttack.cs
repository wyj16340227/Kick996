using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision e)
    {
        Debug.Log("Player On Collision with " + e.gameObject.name + " " + player.state.attackState);
        if (e.gameObject.CompareTag("Enemy"))
        {
            int temp = player.state.attackState;
            float enemyKill = player.state.damage * Player.attackList[temp].damage - e.gameObject.GetComponent<Enemy>().GetDefense();
            if (enemyKill > 0)
            {
                e.gameObject.GetComponent<Enemy>().GetDamage(enemyKill);
            }
        }
    }
}
