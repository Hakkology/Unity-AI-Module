using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyScriptableObject : ScriptableObject
{
    //Personal Stats
    public string Name;
    public int Health;
    public int MeleeBaseHealth = 100;
    public int RangedBaseHealth = 80;
    public int CasterBaseHealth = 60;
    public float BaseHealthCoefficient = 0.4f;
    public int MeleeRadius = 6;
    public int RangedRadius = 10;
    public int CasterRadius = 5;

    //AI Movement Stats
    public float StoppingDistance;
    public float Speed;
    public float Acceleration;
    public float AngularSpeed;

    //AI Attack Stats
    public float MeleeAttackDamage =10;
    public float RangedAttackDamage =8;
    public float CasterAttackDamage =5;
    public float AttackDamageCoefficient = 0.5f;
    public float AttackDamage;

    public float MeleeAttackSpeed = 1;
    public float RangedAttackSpeed = 1.25f;
    public float CasterAttackSpeed = 1.5f;
    public float AttackSpeed;

    public float AttackTime = 0.5f;

    public abstract void Initialize(Enemy enemy);

    protected void SetNavMeshAgentProperties (Enemy enemy) {
        
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();

        if (agent != null) {

            agent.speed = enemy.Stats.Speed;
            agent.stoppingDistance = enemy.Stats.StoppingDistance;
            agent.acceleration = enemy.Stats.Acceleration;
            agent.angularSpeed= enemy.Stats.AngularSpeed;

        }

        else {
            Debug.LogError("NavMeshAgent component not found on the enemy.");
        }

    }

    protected int GetBaseHealth (Enemy enemy) {

        int baseHealth = 0;

        switch (enemy._type) {
            case Enemy.EnemyType.MeleeEnemy:
                baseHealth = MeleeBaseHealth;
                break;
            case Enemy.EnemyType.RangedEnemy:
                baseHealth = RangedBaseHealth;
                break;
            case Enemy.EnemyType.CasterEnemy:
                baseHealth = CasterBaseHealth;
                break;
            default:
                break;
        }

        return baseHealth + Convert.ToInt32(baseHealth * enemy.Level * BaseHealthCoefficient) ;
    }

    protected int GetBaseRadius (Enemy enemy) {

        int radius = 0;

        switch (enemy._type) {
            case Enemy.EnemyType.MeleeEnemy:
                radius = MeleeRadius;
                break;
            case Enemy.EnemyType.RangedEnemy:
                radius = RangedRadius;
                break;
            case Enemy.EnemyType.CasterEnemy:
                radius = CasterRadius;
                break;
            default:
                break;
        }

        return radius;
    }

    protected void SetBaseStats(Enemy enemy) {

        enemy.Stats.BaseHealth= GetBaseHealth(enemy);
        enemy.Stats.Health = enemy.Stats.BaseHealth; //later to be amended due to external factors
        enemy.Stats.Radius = GetBaseRadius(enemy);
    }

    protected float[] GetAttackParameters(Enemy enemy) {

        float[] attackParameters = new float[3];

        switch (enemy._type) {
            case Enemy.EnemyType.MeleeEnemy:
                attackParameters[0] = MeleeAttackDamage + Convert.ToInt32(MeleeAttackDamage * enemy.Level * AttackDamageCoefficient);
                attackParameters[1] = MeleeAttackSpeed;
                attackParameters[2] = AttackTime;
                break;
            case Enemy.EnemyType.RangedEnemy:
                attackParameters[0] = RangedAttackDamage + Convert.ToInt32(RangedAttackDamage * enemy.Level * AttackDamageCoefficient); ;
                attackParameters[1] = RangedAttackSpeed;
                attackParameters[2] = AttackTime;
                break;
            case Enemy.EnemyType.CasterEnemy:
                attackParameters[0] = CasterAttackDamage + Convert.ToInt32(CasterAttackDamage * enemy.Level * AttackDamageCoefficient); ;
                attackParameters[1] = CasterAttackSpeed;
                attackParameters[2] = AttackTime;
                break;
            default: 
                Debug.LogError("Invalid Enemy Type");
                attackParameters[0] = 0;
                attackParameters[1] = 0;
                attackParameters[2] = AttackTime;
                break;
        }

        return attackParameters;
    }

    protected void SetAttackStats(Enemy enemy) {
        enemy.Stats.BaseAttackDamage = GetAttackParameters(enemy)[0];
        enemy.Stats.AttackDamage = enemy.Stats.BaseAttackDamage; //later to be amended due to external factors
        enemy.Stats.BaseAttackSpeed = GetAttackParameters(enemy)[1];
        enemy.Stats.AttackSpeed = enemy.Stats.BaseAttackSpeed; // later to be amended due to external factors
        enemy.Stats.AttackTime = GetAttackParameters(enemy)[2];
    }

}
