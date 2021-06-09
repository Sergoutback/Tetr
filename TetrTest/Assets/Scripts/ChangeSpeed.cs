using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using UnityEngine.SceneManagement;

public class ChangeSpeed : MonoBehaviour
{
    public double seconds = 3;
    public Text TextDispValue;
    
    public void ChangeSpeedSeconds()
    {
        if ( seconds >= 0.5)        
            seconds -= 0.5;        
        else
            seconds = 3;
        
        TextDispValue.text =seconds.ToString();

    }
}
