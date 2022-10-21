using System;
using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Services.SceneLoader
{
    public class SceneLoader : MonoBehaviour
    {
        public void RestartScene()
        {
            ES3AutoSaveMgr.Current.Save();
            SceneManager.LoadScene(0);
        }
    }
}