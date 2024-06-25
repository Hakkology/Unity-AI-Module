using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackStanceState : EnemyState {

    public EnemyAttackStanceState(Enemy enemy) : base(enemy) {

    }

    public override EnemyState Update() {

        if (Helper.CheckPlayerRange(enemy.transform.position, 1f)) return enemy.enemyStateMachine.attackState;
        if (!Helper.CheckPlayerRange(enemy.transform.position, 1.5f)) return enemy.enemyStateMachine.runState;
        return this;
    }
}
