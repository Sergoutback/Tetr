using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeSpeed : MonoBehaviour
{
    public double seconds;
    public Text TextDispValue;
    
    public void ChangeSpeedSeconds()
    {
        if ( seconds >= 1)        
            seconds -= 1;        
        else
            seconds = 5;
        
        TextDispValue.text =seconds.ToString();

    }
}
