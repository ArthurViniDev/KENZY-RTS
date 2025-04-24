using UnityEngine;

public class BaseUnit : MonoBehaviour, ISelectable
{
    public int health;
    public float speed;
    public float range;

    public void OnSelect()
    {
        // logic
    }
    public void OnDeselect()
    {
        // logic
    }
}
