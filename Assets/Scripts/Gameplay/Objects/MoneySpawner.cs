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

    private float upForce;
    private float sideForce;

    private Vector3 spawnForce;

    private GameObject spawnedMoney;

    private void Awake()
    {
        MoneyVFX.SetActive(false);

        upForce = 2.5f;
        sideForce = 0.5f;
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
            spawnForce.x = Random.Range(-sideForce, sideForce);
            spawnForce.y = Random.Range(upForce / 2f, upForce);
            spawnForce.z = Random.Range(-sideForce, sideForce);

            if (spawnForce.x > 0) spawnForce.x += sideForce;
            else spawnForce.x -= sideForce;

            if (spawnForce.z > 0) spawnForce.z += sideForce;
            else spawnForce.z -= sideForce;

            Debug.Log(spawnForce);

            spawnedMoney = Instantiate(Manager.Instance.MoneyPrefab, SpawnPosition.position, Random.rotation);
            spawnedMoney.GetComponent<Rigidbody>().velocity = spawnForce;
            spawnedMoney.GetComponent<Money>().Amount = i != FixedSpawnAmount ? stepAmount : amount % AmountModifier;
        }
    }
}
