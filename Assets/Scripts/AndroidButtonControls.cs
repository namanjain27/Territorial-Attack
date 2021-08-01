using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidButtonControls : MonoBehaviour
{
    public GameObject ExitPrompt;
    public GameObject Pause;

    // Update is called once per frame
    void Update()
    {
        // Make sure user is on Android platform
        if (Application.platform == RuntimePlatform.Android)
        {
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause.SetActive(false);
                ExitPrompt.SetActive(true);
                Pause.GetComponent<PauseMenu>().Pause();
            }
        }
    }
}
