using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineNode _startNode = new();
    private List<LineNode> _nodes = new();
    private LineNode _endNode = new();
    
    private Color _color;
    private Color _voltageColor;
    private float _voltage;

    private static Color _offColor = Color.gray;

    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private LineRenderer _voltageRenderer;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _voltageRenderer = transform.GetChild(0).GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public LineRenderer GetRenderer()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        return _lineRenderer;
    }

    public LineRenderer GetVoltageRenderer()
    {
        _voltageRenderer = transform.GetChild(0).GetComponent<LineRenderer>();
        return _voltageRenderer;
    }

    public List<Vector3> GetPoints()
    {
        List<Vector3> output = new();
        output.Add(_startNode.GetPosition());
        foreach(LineNode lineNode in _nodes)
        {
            output.Add(lineNode.GetPosition());
        }
        output.Add(_endNode.GetPosition());
        return output;
    }

    public void Init(List<LineNode> nodes, Color c)
    {
        _startNode = nodes[0];
        #region Trim Nodes

        List<LineNode> interNodes = new();
        for(int i = 1; i < nodes.Count-1; i++)
        {
            interNodes.Add(nodes[i]);
        }
        #endregion
        _nodes = interNodes;
        _endNode = nodes[nodes.Count-1];
        SetColor(c);
        SetVoltageColor(_offColor);
    }

    public void SetColor(Color color)
    {
        _color = color;
        GetRenderer().startColor = _color;
        GetRenderer().endColor = _color;
    }

    public void SetVoltageColor(Color color)
    {
        _voltageColor = color;
        GetVoltageRenderer().startColor = _color;
        GetVoltageRenderer().endColor = _color;
    }

}


