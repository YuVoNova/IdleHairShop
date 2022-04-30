using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform SpawnPosition;
    [SerializeField]
    private GameObject MoneyVFX;

    [SerializeField]
    private int FixedSpawnAmount;
    [SerializeField]
    private int AmountModifier;

    private int spawnAmount;
    private int stepAmount;

    [SerializeField]
    private float UpForce;
    [SerializeField]
    private float SideForce;

    private Vector3 spawnForce;

    private GameObject spawnedMoney;

    private void Awake()
    {
        MoneyVFX.SetActive(false);
    }

    public void SpawnMoney(int amount)
    {
        MoneyVFX.SetActive(false);
        MoneyVFX.SetActive(true);

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
            spawnForce.x = Random.Range(-SideForce, SideForce);
            spawnForce.y = Random.Range(UpForce / 2f, UpForce);
            spawnForce.z = Random.Range(-SideForce, SideForce);

            if (spawnForce.x > 0) spawnForce.x += SideForce;
            else spawnForce.x -= SideForce;

            if (spawnForce.z > 0) spawnForce.z += SideForce;
            else spawnForce.z -= SideForce;

            spawnedMoney = Instantiate(Manager.Instance.MoneyPrefab, SpawnPosition.position, Random.rotation);
            spawnedMoney.GetComponent<Rigidbody>().velocity = spawnForce;
            spawnedMoney.GetComponent<Money>().Amount = i != FixedSpawnAmount ? stepAmount : amount % AmountModifier;
        }
    }
}
