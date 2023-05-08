using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState {

    public EnemyIdleState(Enemy enemy) : base(enemy) {

    }

    public override EnemyState Update() {

        if (Helper.CheckPlayerRange(enemy.transform.position, 6f)) return enemy.enemyStateMachine.runState;
        return this;
    }
}
