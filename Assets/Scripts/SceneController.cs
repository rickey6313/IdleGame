using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    private static SceneController _instance;

    public static SceneController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SceneController();
            }
            return _instance;
        }
    }

    public IEnumerator LoadSceneAsync(string sceneName)
    {        
        yield return UIManager.Instance.FadeIn();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
            yield return null;

        Scene currentScene = SceneManager.GetActiveScene();        
        asyncLoad = SceneManager.UnloadSceneAsync(currentScene);

        while (!asyncLoad.isDone)
            yield return null;


        yield return UIManager.Instance.FadeOut();

        
        
        
    }
}
