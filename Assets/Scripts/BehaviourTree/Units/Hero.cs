using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hero : MonoBehaviour
{
    [SerializeField] InputReader input;
    [SerializeField] List<GameObject> waypoints = new();

    NavMeshAgent agent;
    AnimationController animations;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        animations = GetComponent<AnimationController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
