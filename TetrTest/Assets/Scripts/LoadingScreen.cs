using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour
{
    public string loadLevel;    
    public Image imageForLoad;
    public Image backgroundImage;
    public GameObject loadingScreen;  

    public void SetActiveTrue ()
    {                  
        loadingScreen.SetActive(true);   
        Debug.Log("loadingScreen.SetActive(true)");  
        StartCoroutine (WaitLoad());           

        IEnumerator WaitLoad() 
        {            
            yield return new WaitForSeconds(3);  
            Debug.Log("WaitLoad(3)");          
            StartAsync();
            Debug.Log("StartAsync()");
        }                 
    }
                    
    
    public void StartAsync ()
    {
        StartCoroutine(AsyncLoad()); 
    
        IEnumerator AsyncLoad()
        {
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadLevel);             
            
            while (!operation.isDone)
            {      
                yield return new WaitForSeconds(5);
                Debug.Log("WaitForSeconds(5)");          
                imageForLoad.fillAmount = operation.progress;                
                backgroundImage.fillAmount = operation.progress;
                Debug.Log("StartCoroutine LoadAsync");                
                yield return null;
                Debug.Log("yield return null");
            }        
        }     
    }    
}
