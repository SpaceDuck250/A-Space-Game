using UnityEngine;
using System;

public class RockWithOreScript : MonoBehaviour
{
    public OreRockData oreRockSetupData;

    public delegate void RockBreakHandler();
    public event Action OnRockBreak;

    public GeneralHealthScript healthScript;


    public OreChunkScript chunkPrefab;

    public float chunkShootSpeed;

    private void Start()
    {
        healthScript.OnDeath += OnBreak;
        OnRockBreak += GenerateRockChunks;

        Invoke("OnBreak", 5);
    }

    private void OnDestroy()
    {
        healthScript.OnDeath -= OnBreak;
        OnRockBreak -= GenerateRockChunks;

    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    healthScript.TakeDamage(1);
        //}


    }

    private void OnBreak()
    {
        OnRockBreak?.Invoke();
    }

    public void GenerateRockChunks()
    {
        int amountOfChunks = GetRandomAmountOfChunks();

        for (int i = 0; i < amountOfChunks; i++)
        {
            // maybe change this later
            int randomAmount = UnityEngine.Random.Range(1, 10);

            GameObject newChunk = CreateNewChunk(GetRandomOreWeighted(), randomAmount);

            Rigidbody2D chunkRb = newChunk.GetComponent<Rigidbody2D>();

            AddRandomForceDirection(chunkRb);
        }

        Destroy(gameObject);
    }

    public void AddRandomForceDirection(Rigidbody2D rb)
    {
        Vector2 randomDirection = UnityEngine.Random.insideUnitCircle;

        rb.AddForce(randomDirection * chunkShootSpeed, ForceMode2D.Impulse);

        rb.angularVelocity = UnityEngine.Random.Range(-20, 20);
    }

    public GameObject CreateNewChunk(ItemData oreData, int amountOfOre)
    {
        OreChunkScript newOreChunk = Instantiate(chunkPrefab, transform.position, Quaternion.identity);

        newOreChunk.SetupSelf(oreData, amountOfOre);

        return newOreChunk.gameObject;
    }

    public int GetRandomAmountOfChunks()
    {
        int randomChunks = UnityEngine.Random.Range(oreRockSetupData.minChunks, oreRockSetupData.maxChunks);
        return randomChunks;
    }

    public ItemData GetRandomOreWeighted()
    {
        float randomValue = UnityEngine.Random.value;
        float cummulative = 0;

        foreach (OreRarityData oreRarity in oreRockSetupData.possibleOreList)
        {
            cummulative += oreRarity.rarityWeight;
            if (randomValue < cummulative)
            {
                return oreRarity.itemData;
            }
        }

        return null;
    }

}
