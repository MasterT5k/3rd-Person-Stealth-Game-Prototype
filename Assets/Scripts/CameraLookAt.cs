using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField]
    private Transform _target = null;

    void Update()
    {
        transform.LookAt(_target);
    }
}
