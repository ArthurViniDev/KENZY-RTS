using System.Collections;
using UnityEngine;

public class BaseResources : MonoBehaviour, ICollectable
{
    public int Amount { get; } = 10;
    public int givenResources = 0;
    public bool resourceIsFull => givenResources >= Amount;

    public void OnCollect(ICollector unitFarming)
    {
        StartCoroutine(Collect());
        if (resourceIsFull) unitFarming.resourcesCollected += givenResources;
    }

    private IEnumerator Collect()
    {
        while(givenResources != Amount)
        {
            yield return new WaitForSeconds(1f);
            givenResources++;
        }
        yield return null;
    }
}
