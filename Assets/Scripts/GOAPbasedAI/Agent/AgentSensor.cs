using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AgentSensor : MonoBehaviour {
    
    [SerializeField] float detectionRadius = 5f;
    [SerializeField] float timerInterval = 1f;


    SphereCollider detectionRange;

    public event Action OnTargetChanged = delegate {};
    public Vector3 TargetPosition => target ? target.transform.position : Vector3.zero;
    public bool IsTargetInRange => TargetPosition != Vector3.zero;

    GameObject target;
    Vector3 lastKnownPosition;
    CountdownTimer timer;

    private void Awake() {
        detectionRange = GetComponent<SphereCollider>();
        detectionRange.isTrigger = true;
        detectionRange.radius = detectionRadius;
    }

    private void Start() {
        timer = new CountdownTimer(timerInterval);
        timer.OnTimerStop += () => {
            UpdateTargetPosition(target.OrNull());
        };
        timer.Start();
    }

    private void Update() {
        timer.Tick(Time.deltaTime);
    }

    void UpdateTargetPosition (GameObject target = null){
        this.target = target;
        if (IsTargetInRange && (lastKnownPosition != TargetPosition || lastKnownPosition != Vector3.zero))
        {
            lastKnownPosition = TargetPosition;
            OnTargetChanged.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(!other.CompareTag("Player")) return;
        UpdateTargetPosition();
    }

    private void OnDrawGizmos() {
        Gizmos.color = IsTargetInRange ? Color.red : Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}