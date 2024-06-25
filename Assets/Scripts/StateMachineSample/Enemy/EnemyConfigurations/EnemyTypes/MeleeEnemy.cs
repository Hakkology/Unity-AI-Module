using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeEnemy", menuName = "ScriptableObjects/EnemyStats/Melee", order = 1)]
public class MeleeEnemy : EnemyScriptableObject {
    public override void Initialize(Enemy enemy) {
        SetNavMeshAgentProperties(enemy);
        SetBaseStats(enemy);
        SetAttackStats(enemy);
    }
}
