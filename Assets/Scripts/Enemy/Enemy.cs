using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    //Configuration definition
    public enum EnemyType {
        MeleeEnemy,
        RangedEnemy,
        CasterEnemy
    }

    [SerializeField] public EnemyType _type;
    [SerializeField] public EnemyScriptableObject _stats;

    public int Level { get; set; }

    public EnemyActualStats Stats;
    public EnemyScriptableObject _enemyConfig => _stats;

    //State Machine
    public EnemyStateMachine enemyStateMachine;

    //Movement AI and animator
    public NavMeshAgent navMeshAgent;
    public Animator animator;

    private void Awake() {

        //Enemy Configuration
        if (_stats != null) {
            _stats.Initialize(this);
        }
        else {
            Debug.LogError("Failed to load enemy stats");
        }

        DebugStats();

        //State Machine initialize
        enemyStateMachine = new EnemyStateMachine(this);

        //Components to be added
        animator = GetComponent<Animator>();
    }

    private void Start() {
        
        enemyStateMachine.Start();
    }

    void Update(){

        enemyStateMachine.Update();

        if (this.Stats.Health <= 0) {
            //get into killing state
        }
    }

    public void DebugStats() {

        Debug.Log("Health: " + Stats.Health);
        Debug.Log("Attack Damage: " + Stats.AttackDamage);
        Debug.Log("Speed: " + Stats.Speed);
    }


}
