using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class GuardAI : MonoBehaviour
{
    [SerializeField]
    private float _offsetDistance = 1f;
    [SerializeField]
    private List<Transform> _waypoints = new List<Transform>();
    private bool _reverse = false;
    private int _currentIndex;
    private NavMeshAgent _agent = null;
    private Animator _anim = null;
    private bool _targetReached = false;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        if (_waypoints.Count < 2)
        {
            _anim.SetBool("Idle", false);
        }
        else
        {
            _anim.SetBool("Idle", true);
        }
    }

    void Update()
    {
        if (_waypoints.Count > 0)
        {
            if (_waypoints[_currentIndex] != null)
            {
                _agent.SetDestination(_waypoints[_currentIndex].position);
            }

            float distance = Vector3.Distance(transform.position, _agent.destination);
            if (distance <= _offsetDistance && _targetReached == false)
            {
                if (_currentIndex == 0 || _currentIndex == _waypoints.Count - 1)
                {
                    _targetReached = true;
                    _anim.SetBool("Idle", true);

                    if (_waypoints.Count < 2)
                    {
                        return;
                    }
                    StartCoroutine(PauseMovementRoutine());
                }
                else
                {
                    if (_reverse == false)
                    {
                        _currentIndex++;
                        if (_currentIndex >= _waypoints.Count - 1)
                        {
                            _reverse = true;
                        }
                    }
                    else
                    {
                        _currentIndex--;
                        if (_currentIndex <= 0)
                        {
                            _reverse = false;
                        }
                    }
                }
            }
        }
    }

    IEnumerator PauseMovementRoutine()
    {
        int randomWait = Random.Range(1, 3);
        yield return new WaitForSeconds(randomWait);
        _targetReached = false;
        _anim.SetBool("Idle", false);
        if (_reverse == false)
        {
            _currentIndex++;
        }
        else
        {
            _currentIndex--;
        }
    }
}
