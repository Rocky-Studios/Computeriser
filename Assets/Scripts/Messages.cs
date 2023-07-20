using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messages : MonoBehaviour
{
    private GameObject _isDrawingLineObject;
    // Start is called before the first frame update
    void Start()
    {
        _isDrawingLineObject = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        _isDrawingLineObject.SetActive(LineController.GetDrawingLine());
    }
}
