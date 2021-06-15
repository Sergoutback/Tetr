using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System;

// Object.DontDestroyOnLoad example.
//
// Two scenes call each other. This happens when OnGUI button is clicked.
// scene1 will load scene2; scene2 will load scene1. Both scenes have
// the Menu GameObject with the SceneSwap.cs script attached.
//
// AudioSource plays an AudioClip as the game runs. This is on the
// BackgroundMusic GameObject which has a music tag.  The audio
// starts in AudioSource.playOnAwake. The DontDestroy.cs script
// is attached to BackgroundMusic.

public class SceneSwap : MonoBehaviour
{
    public GameObject go;
    public ChangeSpeed changeSpeedInSet;
    public float speedInSeconds;

    
    private void OnGUI()
    {
        int xCenter = (Screen.width - Screen.width / 4);
        int yCenter = (Screen.height-Screen.height/2);
        int width = 110;
        int height = 110;

        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("button"));
        fontSize.fontSize = 16;        



        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "1MainScene")
        {
            // Show a button to allow scene2 to be switched to.
            if (GUI.Button(new Rect(xCenter - width / 4, yCenter - height * 4, width, height), "Load \nsecond \nscene", fontSize))
            {
                SceneManager.LoadScene("2SettingsScene");
            }
        }
        else
        {
            // Show a button to allow scene1 to be returned to.
            if (GUI.Button(new Rect(xCenter - width / 4, yCenter - height * 4, width, height), "Return \nto first \nscene", fontSize))
            {
                SceneManager.LoadScene("1MainScene");
                GetSpeedFromChangeSpeed();   
                Debug.Log("changeSpeedInSetOfSceneSwap="+ changeSpeedInSet);                  
            }
        }
    }

    public void SpeedInSeconds()
    {    
        float speedInSeconds = Convert.ToSingle(changeSpeedInSet);
        Debug.Log("speedInSecondsOfSceneSwap="+ speedInSeconds); 
    }
    

    public void GetSpeedFromChangeSpeed()
    {
        // Найти объект по имени
        // GameObject go = GameObject.Find(ChangeSpeed);
        // взять его компонент где лежит скорость
        changeSpeedInSet = go.GetComponent<ChangeSpeed>();
        // взять переменную скорости
        changeSpeedInSet.ChangeSpeedInSet();   
        // Debug.Log("changeSpeedInSetOfGetSpeedFromChangeSpeed="+ changeSpeedInSet); 
        SpeedInSeconds();
        // Debug.Log("speedInSecondsOfGetSpeedFromChangeSpeed="+ speedInSeconds); 
    }
}