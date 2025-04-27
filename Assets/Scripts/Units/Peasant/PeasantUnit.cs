using UnityEngine;

public class PeasantUnit : BaseUnit, ICollector
{
    [Header("Peasant Stats")]
    public int woodAmount { get; set; }
    public int stoneAmount { get; set; }
    public int foodAmount { get; set; }

    private ICollectable currentCollectable;

    public override void OnAttack()
    {
        base.OnAttack();
        currentCollectable = target?.GetComponent<ICollectable>();
        currentCollectable?.OnCollect(this);
    }

    public override void OnEndAttack()
    {
        base.OnEndAttack();
        if (currentCollectable != null)
        {
            currentCollectable.StopCollecting();
            currentCollectable = null; // Limpa depois que para
        }
    }

    public void AddResource(ResourceType resourceType, int amount)
    {
        switch (resourceType)
        {
            case ResourceType.Wood:
                woodAmount += amount;
                break;
            case ResourceType.Stone:
                stoneAmount += amount;
                break;
            case ResourceType.Food:
                foodAmount += amount;
                break;
            default:
                Debug.LogError("Resource type not found");
            break;
        }
    }
}
