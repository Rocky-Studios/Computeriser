using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LineController
{
    private static List<Line> _lines = new();
    private static List<LineNode> _lineNodes = new();
    private static List<Node> _nodes = new();
    private static GameObject _linePrefab;
    private static float lineWidth = 0.05f;
    private static List<LineNode> _nodesInNewLine = new List<LineNode>();
    private static bool _lineStarted = false;
    private static bool _lineFinished = false;
    private static bool _isDrawingLine = false;
    public static void Init()
    {


        foreach (Line l in _lines)
        {
            Update(l);
        }


        if (_linePrefab == null)
            _linePrefab = Resources.Load<GameObject>("Prefab/Line");
    }

    public static void Update(Line l)
    {
        l.GetRenderer().SetPositions(l.GetPoints().ToArray());
        AnimationCurve widthCurve = new();
        widthCurve.AddKey(0, lineWidth);
        l.GetRenderer().widthCurve = widthCurve;
    }

    public static void Loop()
    {
        if (_nodesInNewLine.Count > 0)
        {
            _isDrawingLine = true;
        }
        else
        {
            _isDrawingLine = false;
        }




        if (Input.GetMouseButtonDown(0))
        {
            Vector2 click = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Node closest = GetNearestNode(click);

            if (closest == null)
            {
                if (_lineStarted)
                {
                    //Add intermediate node
                    _nodesInNewLine.Add(new LineNode(click));
                    Debug.Log("added intermediate");
                }



            }
            else
            {
                if (_nodesInNewLine.IndexOf(closest._lineNode) != null)
                {
                    //Add start/end
                    if (_lineStarted)
                    {
                        _lineFinished = true;
                    }
                    if (_nodesInNewLine.Count == 0) _lineStarted = true;
                    _nodesInNewLine.Add(closest._lineNode);
                }

            }


            if (_nodesInNewLine.Count >= 2 && _lineFinished)
            {
                //Finish new line
                GenerateLine(_nodesInNewLine, Color.cyan);
                _nodesInNewLine = new();
                _lineStarted = false;
                _lineFinished = false;
            }
            Debug.Log(_lineStarted);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            //Cancel line
            _nodesInNewLine = new();
            _lineStarted = false;
            _lineFinished = false;
        }
    }

    public static void GenerateLine(List<LineNode> nodes, Color color)
    {
        GameObject line = GameObject.Instantiate(_linePrefab);
        Line l = line.GetComponent<Line>();
        l.Init(nodes, color);
        foreach (LineNode n in nodes)
        {
            n._lines.Add(l);
        }
        l.GetRenderer().numCornerVertices = 8;
        l.GetRenderer().positionCount = nodes.Count;
        Update(l);
    }

    #region OOP Stuff
    public static List<LineNode> GetLineNodes()
    {
        return _lineNodes;
    }

    public static List<Node> GetNodes()
    {
        return _nodes;
    }
    public static Node GetNearestNode(Vector2 click)
    {
        float closest = Mathf.Infinity;

        foreach (Node n in _nodes)
        {
            float distance = Vector2.Distance(click, n.gameObject.transform.position);

            if (distance < closest) closest = distance;
        }

        foreach (Node n in _nodes)
        {
            float distance = Vector2.Distance(click, n.gameObject.transform.position);
            if (distance == closest && distance < 0.1f) return n;
        }

        return null;

    }

    public static bool GetDrawingLine()
    {
        return _isDrawingLine;
    }
    #endregion
}
