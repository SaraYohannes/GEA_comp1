using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenuCall : MonoBehaviour
{
    private void Update()
    {
        ListenForMenuCall();
    }
    public void ListenForMenuCall()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("We heard the escape we are going to menu");
            SceneManager.LoadScene(0);
        }
    }
}
