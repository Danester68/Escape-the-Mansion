using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLevel1 : MonoBehaviour
{
    public GameObject key;
    public GameObject door;
    public GameObject finishUI;

    private bool isFinished;

    public LightScript lightScript;

    public String nextLevelName;
    // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinished && Input.GetKeyDown(KeyCode.Return)) 
        {
            Time.timeScale = 1f;
            SceneManager.LoadSceneAsync(nextLevelName);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Key":
                Debug.Log("Touched key");
                Destroy(key);
                Destroy(door);
                break;
            case "FinishObject":
                finishGame();
                break;
            case "LightSwitch1" or "LightSwitch2":
                lightScript.ToggleLight(collision.gameObject.tag);
                break;
        }
    }
    void finishGame()
    {
        isFinished = true;
        finishUI.SetActive(true);
    }
}