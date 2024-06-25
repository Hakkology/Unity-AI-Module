using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemyActualStats
{
    //Personal Stats
    [SerializeField]public int Health;
    public int BaseHealth;
    [SerializeField] public int Radius;

    //AI Movement Stats
    [SerializeField] public float StoppingDistance;
    [SerializeField] public float Speed;
    [SerializeField] public float Acceleration;
    [SerializeField] public float AngularSpeed;

    //AI Attack Stats
    public float BaseAttackDamage;
    [SerializeField] public float AttackDamage;
    public float BaseAttackSpeed;
    [SerializeField] public float AttackSpeed;
    [SerializeField] public float AttackTime;
}
