using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
//[RequireComponent(typeof(AnimationController))]
public class Agent : MonoBehaviour {
    [Header("Sensors")]
    [SerializeField] AgentSensor chaseSensor;
    [SerializeField] AgentSensor attackSensor;
}