using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void RestartButton()
    {
        GameManager.Instance.RestartGame();
    }

    public void QuitButton()
    {
        GameManager.Instance.QuitGame();
    }
}
