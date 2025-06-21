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
    public GameObject jumpButtonObject;
    public GameObject mobileToggle;

    public TextMeshProUGUI pauseText;

    public KeyCode pauseMenuButton = KeyCode.Escape; // Default key binding

    public bool mobileToggleBool = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
#if UNITY_WEBGL
        pauseText.text = "Pause (P)";
        pauseMenuButton = KeyCode.P;
        mobileToggle.SetActive(true);
        
#elif UNITY_IOS || UNITY_ANDROID
        pauseButtonObject.SetActive(true);
        movementJoystickObject.SetActive(true);
        jumpButtonObject.SetActive(true);
        pauseText.text = "Pause";
        pauseMenuButton = KeyCode.P;
#endif
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_WEBGL
        if (mobileToggleBool)
        {
            Cursor.lockState = CursorLockMode.None;
            pauseButtonObject.SetActive(true);
            movementJoystickObject.SetActive(true);
            jumpButtonObject.SetActive(true);
        }
        else
        {
            pauseButtonObject.SetActive(false);
            movementJoystickObject.SetActive(false);
            jumpButtonObject.SetActive(false);
        }
#endif
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
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void MobileToggleValueChanged(bool value)
    {
        mobileToggleBool = value;
        if (value == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
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
