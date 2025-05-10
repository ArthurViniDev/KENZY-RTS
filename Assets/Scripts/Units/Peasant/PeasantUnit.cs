using UnityEngine;

public class PeasantUnit : BaseUnit, ICollector
{
    [Header("Peasant Stats")]
    public int woodAmount { get; set; }
    public int stoneAmount { get; set; }
    public int foodAmount { get; set; }

    public ResourceType resourceType;

    private ICollectable currentCollectable;

    public override void OnAttack()
    {
        currentCollectable = target?.GetComponent<ICollectable>();
        if(target.GetComponent<BaseResources>().resourceType != resourceType)
        {
            Debug.LogWarning("Resource type not corresponding");
            return;
        }
        base.OnAttack();
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
                PlayerManager.instance.woodAmount += amount;
                break;
            case ResourceType.Stone:
                PlayerManager.instance.stoneAmount += amount;
                break;
            case ResourceType.Food:
                PlayerManager.instance.foodAmount += amount;
                break;
            default:
                Debug.LogError("Resource type not found");
            break;
        }
        woodAmount = 0; stoneAmount = 0; foodAmount = 0;
    }
}
