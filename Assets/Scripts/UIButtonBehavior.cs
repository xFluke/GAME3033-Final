using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonBehavior : MonoBehaviour
{
    public void ReturnToMainMenu() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

    }

    public void PlayButton() {
        SceneManager.LoadScene("Gameplay");
    }
}
