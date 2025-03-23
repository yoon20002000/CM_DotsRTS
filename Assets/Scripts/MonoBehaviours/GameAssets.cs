using System;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public const string UNITS_LAYER_NAME = "Units";
    public static GameAssets Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }

    public uint GetUnitLayer()
    {
        return getLayerByName(UNITS_LAYER_NAME);
    }
    private uint getLayerByName(string name)
    {
        return (uint)1 << LayerMask.NameToLayer(name);
    }
}
