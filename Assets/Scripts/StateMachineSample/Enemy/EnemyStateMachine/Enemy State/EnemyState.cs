using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{

    public Enemy enemy;

    public EnemyState(Enemy enemy) {

        this.enemy = enemy;
    }

    public abstract EnemyState Update();
}
