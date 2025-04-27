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
        if (currentCollectable == null || !target) 
        {
            isAttacking = false;
            return;
        }
        
        currentCollectable.StopCollecting();
        currentCollectable = null;
        base.OnEndAttack();
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
