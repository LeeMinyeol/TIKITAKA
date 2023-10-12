using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{
    public void LoadScene(int sceneNum)
    {
        LoadingSceneController.LaodScene(sceneNum);
    }
}
