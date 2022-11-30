using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public void PlayGameButton()
    {
        SceneManager.LoadScene("MenuGame", LoadSceneMode.Additive);
    }
}
