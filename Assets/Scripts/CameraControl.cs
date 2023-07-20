using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float _zoom;
    private const float _maxZoom = 5f;
    private const float _minZoom = 1f;
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.mouseScrollDelta.y * 1;
        if(x!=0)
        {
            _zoom -= x;
            SetZoom();
        }

        Vector3 movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement *= 0.1f;
        movement *= _zoom / _maxZoom;
        transform.position += movement;
    }

    private void SetZoom()
    {
        if(_zoom > _maxZoom) _zoom = _maxZoom;
        else if(_zoom < _minZoom) _zoom = _minZoom;
        _camera.orthographicSize = _zoom;
    }
}
