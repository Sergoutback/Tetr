using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void ChangeFromStartToMain()
    {
        SceneManager.LoadScene(1);
    }    
    public void ChangeFromSceneToHome()
    {
        SceneManager.LoadScene(0);
    }  
    public void ChangeFromStartToSettings()
    {
        SceneManager.LoadScene(2);
    } 
}