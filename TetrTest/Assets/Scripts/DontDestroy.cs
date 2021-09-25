using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

// Object.DontDestroyOnLoad example.
//
// This script example manages the playing audio. The GameObject with the
// "music" tag is the BackgroundMusic GameObject. The AudioSource has the
// audio attached to the AudioClip.

public class DontDestroy : MonoBehaviour
{
    public GameObject goDontDestroy;
    public ChangeSpeed changeSpeedInSet;
    public float speedInDontDestroy;


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Speed");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        Debug.Log("speedAfterDontDestroyOnLoad="+ speedInDontDestroy ); 
    }

    public void SpeedInDontDestroy ()
    {    
        float speedInDontDestroy  = Convert.ToSingle(changeSpeedInSet);
        Debug.Log("speedInSwapOfSceneDontDestroy="+ speedInDontDestroy ); 
    }

    public void GetSpeedFromChangeSpeed()
    {
        // Найти объект по имени
        // GameObject go = GameObject.Find(ChangeSpeed);
        // взять его компонент где лежит скорость
        changeSpeedInSet = goDontDestroy.GetComponent<ChangeSpeed>();
        // взять переменную скорости
        changeSpeedInSet.ChangeSpeedInSet();   
        Debug.Log("changeSpeedInSet="+ changeSpeedInSet); 
        SpeedInDontDestroy ();
        Debug.Log("speedInDontDestroy="+ speedInDontDestroy); 
    }    
}