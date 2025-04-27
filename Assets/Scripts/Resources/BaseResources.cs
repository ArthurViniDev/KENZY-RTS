using System.Collections;
using UnityEngine;

public enum ResourceType
{
    Wood,
    Stone,
    Food
}

public class BaseResources : MonoBehaviour, ICollectable
{
    private Coroutine collectCoroutine = null;

    public int Amount { get; } = 5;
    public int givenResources = 0;
    public bool resourceIsFull => givenResources >= Amount;

    public ICollector thisUnitFarming { get; set; } = null;

    [Header("Resource Type")]
    public ResourceType resourceType;

    public void OnCollect(ICollector unitFarming)
    {
        thisUnitFarming = unitFarming;
        collectCoroutine = StartCoroutine(Collect());
    }

    private void OnEndCollect()
    {
        thisUnitFarming.AddResource(resourceType, givenResources);
        Destroy(gameObject);
    }

    public void StopCollecting()
    {
        if (collectCoroutine != null)
        {
            StopCoroutine(collectCoroutine);
            collectCoroutine = null;
        }
        thisUnitFarming = null;
    }

    private IEnumerator Collect()
    {
        while(givenResources != Amount)
        {
            yield return new WaitForSeconds(1f);
            givenResources++;
            if(resourceIsFull)
            {
                OnEndCollect();
                yield break;
            }
        }
    }
}
