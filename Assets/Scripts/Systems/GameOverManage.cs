using System;
using UnityEngine;
using UnityEngine.SceneManagement; //Add a scenemanager.

public class GameOverManage : MonoBehaviour
{
    // We will add a start function to the GameoverManager so we can get our mouse behaviour back again.
    private void Start()
    {
        // We need to unlock the cursor lock and the make the cursor visible again. I put this in because somethings it hard locks it between scenes.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Restart button function/event
    public void RestartButton()
    {
        //Using SceneManager to load the scene I want to load with the index number. Async is used to load in the operation. Usable for preloading, loading bars etc.
        SceneManager.LoadSceneAsync(0);
    }
}
