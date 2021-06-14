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
        Debug.Log("StartCoroutine ForMess");
    }
    IEnumerator ForMess() 
        {                    
        yield return new WaitForSeconds(1);
        messageText.text = "\nPush for\ndownload\npage!";
        }

    public void Message_Cliked()
    {   
        {
            StartCoroutine (ForMess2());
            Debug.Log("StartCoroutine ForMess2");
        }
        IEnumerator ForMess2() 
        {
            messageText.text = "\n\nYes,";
            yield return new WaitForSeconds(1); 
            messageText.text = "\n\nbaby!";    
        }    
    }
}
