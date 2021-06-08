using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField]
    private GameObject _cutsceneObj = null;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_cutsceneObj != null)
            {
                if (_cutsceneObj.activeInHierarchy == false)
                {
                    _cutsceneObj.SetActive(true);
                }
            }
        }
    }
}
