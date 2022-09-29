using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _serveButton;

    public void ActiveButton()
    {
        _serveButton.SetActive(true);
    }
}
