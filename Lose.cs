using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lOSE : MonoBehaviour
{
    public string sceneName;
    public int escape;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            escape++;
            if (escape > 30)
            {
                Application.Quit(200);
                Debug.Log("Quit application");
            }
        }
        else
        {
            escape = 0;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
