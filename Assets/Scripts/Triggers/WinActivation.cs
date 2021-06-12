using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _winCutscene = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.CheckForKeycard() == true)
            {
                if (_winCutscene != null)
                {
                    _winCutscene.SetActive(true);
                }
            }
        }
    }
}
