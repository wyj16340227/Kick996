using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer : MonoBehaviour
{
    public abstract void ReactionPlayer(PlayerState playerState);

    public abstract void ReactionEnemy(int enemyNum, int bossNum);
}
