using UnityEngine;

public class PeasantUnit : BaseUnit, ICollector
{
    public int resourcesCollected { get; set; } = 0;

    [Header("Peasant Stats")]
    public int woodAmount;
    public int stoneAmount;
    public int foodAmount;

    public override void OnAttack()
    {
        base.OnAttack();
        TargetCollectable?.OnCollect(this);
    }
}
