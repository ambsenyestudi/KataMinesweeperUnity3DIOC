using UnityEngine;
using System.Collections;
using System;

public class TileGenerator
{

    // Use this for initialization
    public string[] GenerateField(int v1, int v2, string[] v3)
    {
        if (v1 > 1)
        {
            if (v2 > 1)
            {
                return new string[] { "00", "00" };
            }
            return new string[] { "00" };
        }
        else
        {
            return new string[] { "0" };
        }
    }
}
