using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "OreRockData", menuName = "Scriptable Objects/OreRockData")]
public class OreRockData : ScriptableObject
{
    public List<OreRarityData> possibleOreList = new List<OreRarityData>();

    public int minChunks = 3;
    public int maxChunks;


}

[Serializable]
public class OreRarityData
{
    public ItemData itemData;
    public float rarityWeight;
}