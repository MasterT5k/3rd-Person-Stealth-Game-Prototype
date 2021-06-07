using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _clickEffect = null;

    private bool _isMoving = false;
    private NavMeshAgent _agent = null;
    private Animator _anim = null;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Animator is NULL");
        }
    }

    void Update()
    {
        //if (_isMoving == true && _agent.hasPath == false)
        //{
        //    _anim.SetBool("Walk", false);
        //    _isMoving = false;
        //}

        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                _agent.SetDestination(hitInfo.point);
                GameObject effect = Instantiate(_clickEffect, hitInfo.point, Quaternion.identity);
                Destroy(effect, 1f);

                if (_isMoving == false)
                {
                    _anim.SetBool("Walk", true);
                    _isMoving = true;
                }
            }
        }

        if (_isMoving == true)
        {
            float distance = Vector3.Distance(transform.position, _agent.destination);
            if (distance <= 1.5f)
            {
                _anim.SetBool("Walk", false);
                _isMoving = false;
            }
        }
    }
}
