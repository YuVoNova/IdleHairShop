using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform SpawnPosition;

    [SerializeField]
    private int FixedSpawnAmount;
    [SerializeField]
    private int AmountModifier;

    private int spawnAmount;
    private int stepAmount;

    private float upForce;
    private float sideForce;

    private Vector3 spawnForce;

    private GameObject spawnedMoney;

    private void Awake()
    {
        upForce = 5f;
        sideForce = 0.8f;
    }

    public void SpawnMoney(int amount)
    {
        if (amount % AmountModifier == 0)
        {
            spawnAmount = FixedSpawnAmount;
            stepAmount = amount / AmountModifier;
        }
        else
        {
            spawnAmount = FixedSpawnAmount + 1;
            stepAmount = Mathf.FloorToInt(amount / (float) AmountModifier);
        }

        spawnForce = Vector3.zero;
        for (int i = 0; i < spawnAmount; i++)
        {
            spawnForce.x = Random.Range(-sideForce, sideForce);
            spawnForce.y = Random.Range(upForce / 2f, upForce);
            spawnForce.z = Random.Range(-sideForce, sideForce);

            spawnedMoney = Instantiate(Manager.Instance.MoneyPrefab, SpawnPosition.position, Random.rotation);
            spawnedMoney.GetComponent<Rigidbody>().velocity = spawnForce;
            spawnedMoney.GetComponent<Money>().Amount = i != FixedSpawnAmount ? stepAmount : amount % AmountModifier;
        }
    }
}
