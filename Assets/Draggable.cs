using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector2 _pastMousePos = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);



        if (Input.GetMouseButton(0) && Vector3.Distance(mouse, transform.position) < 0.35f)
        {
            float differenceX = (mouse.x - _pastMousePos.x);
            float differenceY = (mouse.y - _pastMousePos.y);

            Vector3 difference = new Vector3(differenceX, differenceY);

            transform.position += difference;
        }









        _pastMousePos = mouse;
    }
}
