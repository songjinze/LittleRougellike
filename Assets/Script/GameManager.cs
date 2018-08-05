using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private BoardManager boardManager;
    public static GameManager instance = null;
    public int playerFoodPoint = 100;
    public int playerHealthPoint = 100;
    public int level=1;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        boardManager = GetComponent<BoardManager>();
        InitGame();
    }
    //this is called only once, and the paramter tell it to be called only after the scene was loaded
    //(otherwise, our Scene Load callback would be called the very first load, and we don't want that)
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static public void CallbackInitialization()
    {
        //register the callback to be called everytime the scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //This is called each time a scene is loaded.
    static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        instance.InitGame();
        instance.level++;
    }
    void InitGame()
    {
        
        boardManager.SetupScene(level);
    }
    
}
