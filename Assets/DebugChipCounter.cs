using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugChipCounter : MonoBehaviour
{
    private TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = "Chips: " + ChipController.GetChips().Count;
    }
}
