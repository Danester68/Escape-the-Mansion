using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvasManager : MonoBehaviour
{
    public GameObject pauseButtonObject;
    public GameObject pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
#if UNITY_WEBGL || UNITY_IOS || UNITY_ANDROID
            pauseButtonObject.SetActive(true);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the escape key is pressed to toggle the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
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
