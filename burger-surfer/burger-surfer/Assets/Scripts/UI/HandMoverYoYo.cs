using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandMoverYoYo : MonoBehaviour
{
    [SerializeField] private Vector3[] _points;

    private float _duration = 2;

    private void Start()
    {
        Tween tween = transform.DOPath(_points, _duration, PathType.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
