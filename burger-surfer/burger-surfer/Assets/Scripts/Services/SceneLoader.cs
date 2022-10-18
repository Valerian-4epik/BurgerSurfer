using System;
using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Services.SceneLoader
{
    public class SceneLoader : MonoBehaviour
    {
        private IEnumerator Awake()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            yield break;
#endif
            yield return YandexGamesSdk.Initialize();
            
            DontDestroyOnLoad(this);
        }

        public void RestartScene()
        {
            VideoAd.Show();

            ES3AutoSaveMgr.Current.Save();
            SceneManager.LoadScene(0);
        }
    }
}