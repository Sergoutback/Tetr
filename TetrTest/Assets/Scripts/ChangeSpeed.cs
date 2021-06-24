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
    
    public void ChangeSpeedInSet()
    {
        TextDispValue.text =speed.ToString();
        Debug.Log("speedInChangeSpeed="+ speed);        

        if (speed <= 3)        
            speed+= 1;        
        else
            speed = 1;  
    }       
}
