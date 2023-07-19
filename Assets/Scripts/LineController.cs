using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LineController
{
    private static List<Line> _lines = new();
    private static List<LineNode> _nodes = new();
    private static GameObject _linePrefab;
    private static float lineWidth = 0.1f;
    
    public static void Init()
    {
        

        foreach(Line l in _lines)
        {
            Update(l);
        }

        
        if (_linePrefab == null)
            _linePrefab = Resources.Load<GameObject>("Prefab/Line");
        GenerateLine(_nodes, Color.cyan);
    }

    public static void Update(Line l)
    {
        l.GetRenderer().SetPositions(l.GetPoints().ToArray());
        AnimationCurve widthCurve = new();
        widthCurve.AddKey(0, lineWidth);
        l.GetRenderer().widthCurve = widthCurve;
        
    }

    public static void GenerateLine(List<LineNode> nodes, Color color)
    {
        GameObject line = GameObject.Instantiate(_linePrefab);
        Line l = line.GetComponent<Line>();
        l.Init(nodes, color);

        foreach(LineNode n in nodes)
        {
            n._lines.Add(l);
        }


        Update(l);
    }

    public static List<LineNode> GetNodes()
    {
        return _nodes;
    }
}
