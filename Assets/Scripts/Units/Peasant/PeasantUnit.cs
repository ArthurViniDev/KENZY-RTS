using UnityEngine;

public class PeasantUnit : BaseUnit, ICollector
{
    [Header("Peasant Stats")]
    public int woodAmount { get; set; }
    public int stoneAmount { get; set; }
    public int foodAmount { get; set; }

    public override void OnAttack()
    {
        base.OnAttack();
        TargetCollectable?.OnCollect(this);
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
