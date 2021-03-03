using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraStartZoomOut : MonoBehaviour
{
    public Camera _camera;

    void Start()
    {
        //DOTween.To(() => _camera.Size, x => myFloat = x, 52, 1);
        _camera.DOOrthoSize(4.68f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
