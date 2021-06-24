using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object.DontDestroyOnLoad example.
//
// This script example manages the playing audio. The GameObject with the
// "music" tag is the BackgroundMusic GameObject. The AudioSource has the
// audio attached to the AudioClip.

public class DontDestroy : MonoBehaviour
{
    public GameObject goSceneSet;
    public ChangeSpeed changeSpeedInSet;


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Speed");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void GetspeedfromSet()
    {

        changespeedinSet = goSceneSet.getcomponent<ChangeSpeed>();

        changeSpeedInSet.ChangeSpeedInSet();

    }
    public void speedoftetr()
    {
        float speedoftetr = convert.tosingle(changeSpeedInSet);
    }
}