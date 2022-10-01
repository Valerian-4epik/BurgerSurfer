using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void RestartScene()
    {
        ES3AutoSaveMgr.Current.Save();
        SceneManager.LoadScene(0);
    }
}
