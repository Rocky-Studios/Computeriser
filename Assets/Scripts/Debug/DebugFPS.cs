using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugFPS : MonoBehaviour
{
    //Declare these in your class
    int _frameCounter = 0;
    float _timeCounter = 0.0f;
    float _lastFramerate = 0.0f;
    public float _refreshTime = 0.5f;

    private TMP_Text text;

    void Update()
    {
        if (_timeCounter < _refreshTime)
        {
            _timeCounter += Time.deltaTime;
            _frameCounter++;
        }
        else
        {
            //This code will break if you set your m_refreshTime to 0, which makes no sense.
            _lastFramerate = (float)_frameCounter / _timeCounter;
            _frameCounter = 0;
            _timeCounter = 0.0f;
        }

        text.text = "FPS: " + Mathf.Round(_lastFramerate);
    }

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }
}
