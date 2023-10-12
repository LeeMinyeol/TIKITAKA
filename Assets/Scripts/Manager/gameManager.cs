using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private TweenManager tweenManager;
    [SerializeField] private MySceneManager mySceneManager;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
