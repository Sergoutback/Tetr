using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System;

public class ChangeSpeed : MonoBehaviour
{
    public  int speed;
    public Text TextDispValue;  

    public GameObject groupGO;
    public  Group speedForGroup;

    
    public void ChangeSpeedInSet()
    {
        TextDispValue.text =speed.ToString();
        Debug.Log("speedOfChangeSpeedSeconds="+ speed);        

        if (speed >= 1)        
            speed-= 1;        
        else
            speed = 5;  

        speedForGroup = groupGO.GetComponent<Group>();
        speedForGroup.speedInSeconds = Convert.ToSingle(speed);

    }           
}
