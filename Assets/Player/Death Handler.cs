using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    FirstPersonController firstPersonController;

    private void Start() {
        gameOverCanvas.enabled = false;
        firstPersonController = FindObjectOfType<FirstPersonController>();
    }

    public void HandleDeath()
    {
        // SceneManager.LoadScene(0);
        gameOverCanvas.enabled = true;
        firstPersonController.enabled = false;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
