using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera1;
    [SerializeField]
    private Camera _camera2;

    private bool _cameraEnabled = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _camera1.enabled = _cameraEnabled;
            _camera2.enabled = !_cameraEnabled;
            _cameraEnabled = !_cameraEnabled;
        }
    }
}
