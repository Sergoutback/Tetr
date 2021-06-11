using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForMessages : MonoBehaviour
{
    public Text messageText;    
    void Start()
    {
        StartCoroutine (ForMess ());
    }
    IEnumerator ForMess() 
        {                    
        yield return new WaitForSeconds(3);
        messageText.text = "Push me\nfor\ndownloading\npage!";
        }

    public void Message_Cliked()
    {   
        messageText.text = "\nHello!\nLet's play!";              
    }
}
