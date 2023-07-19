using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private List<Node>  _inputs = new List<Node>();
    [SerializeField] private List<Node> _outputs = new List<Node>();
    [SerializeField] private Color _color = Color.gray;
    [SerializeField] private ChipType _chipType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private enum ChipType
    {
        AndGate,
        NandGate,
        NorGate,
        NotGate,
        OrGate,
        XnorGate,
        XorGate
    }
}

