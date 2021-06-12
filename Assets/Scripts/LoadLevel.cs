using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private Image _loadingBar = null;

    void Start()
    {
        StartCoroutine(LoadLevelASync());
    }

    IEnumerator LoadLevelASync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");

        while (operation.isDone == false)
        {
            _loadingBar.fillAmount = Mathf.Clamp01(operation.progress / 0.9f);
            yield return new WaitForEndOfFrame();
        }
    }
}
