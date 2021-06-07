using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform _cameraTrans = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Camera.main.transform.position = _cameraTrans.position;
            Camera.main.transform.rotation = _cameraTrans.rotation;
        }
    }
}
