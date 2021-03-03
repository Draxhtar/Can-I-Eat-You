using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraStartZoomOut : MonoBehaviour
{
    public Camera _camera;

    void Start()
    {
        _camera.DOOrthoSize(4.68f, 1f);
    }
    /* It's just to zoom out the camera at the start of the game, it's kinda cool */
}
