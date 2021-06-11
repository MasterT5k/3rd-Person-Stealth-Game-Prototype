using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GrabKeyCardActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _cutsceneObj = null;
    private bool _hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _hasPlayed == false)
        {
            if (_cutsceneObj != null)
            {
                _hasPlayed = true;
                _cutsceneObj.SetActive(true);
                GameManager.Instance.SetKeycard(true);
            }
        }
    }
}
