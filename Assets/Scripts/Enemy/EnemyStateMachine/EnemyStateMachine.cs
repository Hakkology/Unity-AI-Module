using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public Enemy enemy;
    public EnemyState currentState;

    public EnemyState idleState, runState, attackStanceState, attackState;

    public EnemyStateMachine (Enemy enemy) {

        this.enemy = enemy;
    }

    public void Start() {

        idleState = new EnemyIdleState(enemy);
        runState= new EnemyRunState(enemy);
        attackStanceState = new EnemyAttackStanceState(enemy);
        attackState= new EnemyAttackState(enemy);

        currentState = idleState;
    }

    public void Update() {

        currentState = currentState.Update();
    }
}
