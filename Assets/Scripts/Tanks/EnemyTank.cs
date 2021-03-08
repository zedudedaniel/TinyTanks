using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : Tank
{
    private LevelEnder tankCounter;
    void Awake()
    {
        tankCounter = Object.FindObjectOfType<LevelEnder>();
        tankCounter.enemyTanks.Add(this);
    }

    void OnDestroy() {
        Debug.Log("I am dead!");
        tankCounter.enemyTanks.Remove(this);
        if (tankCounter.enemyTanks.Count == 0) { //If there are no more enemy tanks
            tankCounter.nextLevel(); //Go to next level!
        }
    }
}
