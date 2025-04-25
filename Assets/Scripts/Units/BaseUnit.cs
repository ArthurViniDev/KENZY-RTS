using UnityEngine;

public class BaseUnit : MonoBehaviour, ISelectable
{
    public int health;
    public float speed;
    public float range;

    [SerializeField] private GameObject selectionMark;

    void Start()
    {
        selectionMark = transform.GetChild(0).gameObject;
    }

    public void OnSelect()
    {
        selectionMark.SetActive(true);
    }
    public void OnDeselect()
    {
        selectionMark.SetActive(false);
    }
}
