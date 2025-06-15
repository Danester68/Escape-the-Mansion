using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCanvasManager : MonoBehaviour
{
    public GameObject pauseButtonObject;
    public GameObject pauseMenu;
    public GameObject movementJoystickObject;

    public TextMeshProUGUI pauseText;

    public KeyCode pauseMenuButton = KeyCode.Escape; // Default key binding

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Remove UNITY_EDITOR after testing is finished
#if UNITY_WEBGL || UNITY_IOS || UNITY_ANDROID || UNITY_EDITOR
        pauseButtonObject.SetActive(true);
        movementJoystickObject.SetActive(true);
#endif
#if UNITY_WEBGL || UNITY_EDITOR
        pauseText.text = "Pause (P)";
        pauseMenuButton = KeyCode.P;
#elif UNITY_IOS || UNITY_ANDROID
        pauseText.text = "Pause";
        pauseMenuButton = KeyCode.P;
#endif
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Check if the escape key is pressed to toggle the pause menu
        if (Input.GetKeyDown(pauseMenuButton))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        if (pauseMenu.activeInHierarchy == false)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
        }
        else if (pauseMenu.activeInHierarchy == true)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseMenu.SetActive(false);
        }
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    }
}
