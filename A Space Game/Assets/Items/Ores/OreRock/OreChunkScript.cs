using UnityEngine;

public class OreChunkScript : MonoBehaviour
{
    public ItemData oreStored;
    public int amount;

    public void SetupSelf(ItemData oreStored, int amount)
    {
        this.oreStored = oreStored;
        this.amount = amount;
    }
}
