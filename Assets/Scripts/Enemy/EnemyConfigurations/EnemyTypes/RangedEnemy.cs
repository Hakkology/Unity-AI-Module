using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedEnemy", menuName = "ScriptableObjects/EnemyStats/Ranged", order = 2)]
public class RangedEnemy : EnemyScriptableObject
{
    // Start is called before the first frame update
    public override void Initialize(Enemy enemy) {
        SetNavMeshAgentProperties(enemy);
        SetBaseStats(enemy);
        SetAttackStats(enemy);
    }
}
