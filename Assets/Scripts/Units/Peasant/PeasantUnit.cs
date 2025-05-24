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
        if (!Target) return;

        float distance = Vector3.Distance(transform.position, Target.transform.position);
        if (distance > stopDistance) return;

        currentCollectable = Target?.GetComponent<ICollectable>();
        if (Target?.GetComponent<BaseResources>().resourceType != resourceType) return;

        currentCollectable?.OnCollect(this);
        base.OnAttack();
    }

    public override void EndAttack()
    {
        if (currentCollectable == null || !Target)
        {
            isAttacking = false;
            return;
        }

        currentCollectable.StopCollecting();
        currentCollectable = null;
        base.EndAttack();
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
