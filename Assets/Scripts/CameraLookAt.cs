using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField]
    private Transform _target = null;
    [SerializeField]
    private Transform _startingView = null;

    private void Start()
    {
        transform.position = _startingView.position;
        transform.rotation = _startingView.rotation;
    }

    void Update()
    {
        transform.LookAt(_target);
    }
}
