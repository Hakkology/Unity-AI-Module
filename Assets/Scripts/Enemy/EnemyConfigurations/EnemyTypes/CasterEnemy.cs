using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CasterEnemy", menuName = "ScriptableObjects/EnemyStats/Caster", order = 3)]
public class CasterEnemy : EnemyScriptableObject
{
    public override void Initialize(Enemy enemy) {
        SetNavMeshAgentProperties(enemy);
        SetBaseStats(enemy);
        SetAttackStats(enemy);
    }
}
