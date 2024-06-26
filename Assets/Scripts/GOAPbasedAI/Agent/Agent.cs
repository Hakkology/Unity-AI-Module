using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AnimationController))]
public class Agent : MonoBehaviour {
    [Header("Sensors")]
    [SerializeField] AgentSensor chaseSensor;
    [SerializeField] AgentSensor attackSensor;

    [Header("Known Locations")]
    [SerializeField] Transform restingPosition;
    [SerializeField] Transform foodShack;
    [SerializeField] Transform doorOnePosition;
    [SerializeField] Transform doorTwoPosition;

    NavMeshAgent navMeshAgent;
    AnimationController animations;
    Rigidbody rb;

    [Header("Stats")]
    public float health = 100;
    public float stamina = 100;

    // references for others
    CountdownTimer statsTimer;
    GameObject target;
    Vector3 destination;

    // references for agent related
    AgentGoal lastGoal;
    public AgentGoal currentGoal;
    public AgentAction currentAction;
    public AgentActionPlan actionPlan;

    // beliefs, actions and goals
    public Dictionary<string, AgentBelief> beliefs;
    public HashSet<AgentAction> actions;
    public HashSet<AgentGoal> goals;

    private void Awake() {

        navMeshAgent = GetComponent<NavMeshAgent>();
        animations = GetComponent<AnimationController>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Start() {
        SetupTimers();
        SetupBeliefs();
        SetupActions();
        SetupGoals();
    }

    private void SetupGoals() {
        goals = new HashSet<AgentGoal>();

        goals.Add (new AgentGoal.Builder("Chill Out")
            .WithPriority(1)
            .WithDesiredEffect(beliefs["Nothing"])
            .Build());
        
        goals.Add (new AgentGoal.Builder("Wander")
            .WithPriority(1)
            .WithDesiredEffect(beliefs["AgentMoving"])
            .Build());
        

    }

    private void SetupActions() {
        actions = new HashSet<AgentAction>();

        actions.Add(new AgentAction.Builder("Relax")
            .WithStrategy(new IdleStrategy(5))
            .AddEffect(beliefs["Nothing"])
            .Build());
        
        actions.Add(new AgentAction.Builder("Wander Around")
            .WithStrategy(new WanderStrategy(navMeshAgent, 10))
            .AddEffect(beliefs["AgentMoving"])
            .Build());
    }

    private void SetupBeliefs(){
        beliefs = new Dictionary<string, AgentBelief>();
        BeliefFactory factory = new BeliefFactory(this, beliefs);

        factory.AddBelief("Nothing", () => false);
        factory.AddBelief("AgentIdle", () => !navMeshAgent.hasPath);
        factory.AddBelief("AgentMoving", () => navMeshAgent.hasPath);
    }

    void SetupTimers()
    {
        statsTimer = new CountdownTimer(2f);
        statsTimer.OnTimerStop += () => {
            UpdateStats();
            statsTimer.Start();
        };
        statsTimer.Start();
    }

    private void UpdateStats(){
        stamina += InRangeOf(restingPosition.position, 3f) ? 20: 10;
        health += InRangeOf(foodShack.position, 3f) ? 20 : -5;
        stamina = Mathf.Clamp(stamina, 0, 100);
        health = Mathf.Clamp(health, 0, 100);
    }

    bool InRangeOf(Vector3 pos, float range) => Vector3.Distance(transform.position, pos) < range;

    void OnEnable() => chaseSensor.OnTargetChanged += HandleTargetChanged;
    void OnDisable() => chaseSensor.OnTargetChanged += HandleTargetChanged;

    void HandleTargetChanged(){
        Debug.Log("Target changed, clearing current action and goal");
        currentAction = null;
        currentGoal = null;
    }

}
