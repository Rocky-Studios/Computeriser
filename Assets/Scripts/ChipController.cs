using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ChipController
{
    private static List<Chip> _chips = new List<Chip>();

    public static List<Chip> GetChips()
    {
        return _chips;
    }
}
