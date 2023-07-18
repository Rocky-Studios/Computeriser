using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public LineNode _lineNode;
    
    // Start is called before the first frame update
    void Awake()
    {
        _lineNode = new LineNode(transform.position);
        LineController.GetNodes().Add(_lineNode);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.hasChanged)
        {
            
            _lineNode.Update();
            
        }
    }
}

public class LineNode
{
    private Vector2 _position;
    public List<Line> _lines;

    public Vector2 GetPosition()
    {
        return _position;
    }

    public LineNode(Vector2 position)
    {
        _position = position;
    }

    public LineNode()
    {
       
    }

    public void Update()
    {
        foreach (Line line in _lines)
        {
            LineController.Update(line);
        }
    }
}