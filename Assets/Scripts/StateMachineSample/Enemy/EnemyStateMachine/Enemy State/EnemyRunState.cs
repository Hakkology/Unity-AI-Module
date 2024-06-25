using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunState : EnemyState {

    public EnemyRunState(Enemy enemy) : base(enemy) {

    }

    public override EnemyState Update() {

        if (Helper.CheckPlayerRange(enemy.transform.position, 1f)) return enemy.enemyStateMachine.attackStanceState; 
        return this;
    }
}
