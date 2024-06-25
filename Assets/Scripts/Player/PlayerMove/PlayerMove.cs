using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMove : MonoBehaviour {

    [SerializeField] private NavMeshAgent _agent;
    private Camera _camera;
    [SerializeField] public Animator _playerAnim;

    private Ray _ray;
    private RaycastHit _hit;

    bool _isMoving = false;

    private static readonly int _GROUND_LAYER = 1 << 6;

    private void Awake() {

        _agent = GetComponent<NavMeshAgent>();
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update() {

        MovementControls();
    }

    void MovementControls() {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(_ray, out _hit, 1000f, _GROUND_LAYER)) {
                _agent.destination = _hit.point;
            }
        }

        if (_agent.velocity.sqrMagnitude > 0.01f) {
            if (!_isMoving) {
                _isMoving = true;
                
            }
            Run();
        }
        else {
            if (_isMoving) {
                _isMoving = false;
                
            }
            Idle();
        }
    }

    void ShootingControls() {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(1)) {

        }
    }

    void Idle() {
        // Idle animation
        _playerAnim.SetFloat("Running", 0f, 0.1f, Time.deltaTime);
    }

    void Run() {

        // animation controls with running animation
        _playerAnim.SetFloat("Running", 1f, 0.1f, Time.deltaTime);
    }

    void Shoot() {

        _playerAnim.SetBool("isCasting", true);
    }
}
