using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour
{
    public string loadLevel;
    public GameObject loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load ()
    {
        loadingScreen.SetActive(true);
        // SceneManager.LoadScene(loadLevel);

        StartCoroutine(LoadAdync());
    }

    IEnumerator LoadAdync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadLevel);
        
            while (!asyncLoad.isDone)
            {
                yield return null;
            }        
    }
}
