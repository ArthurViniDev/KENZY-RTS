using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BaseUnit : MonoBehaviour, ISelectable
{
    public int health;
    public float speed;
    public float range;

    [SerializeField] private GameObject selectionMark;
    [SerializeField] private NavMeshAgent agent;

    void Start()
    {
        selectionMark = transform.GetChild(0).gameObject;
        agent = GetComponent<NavMeshAgent>();
    }
    public void OnSelect()
    {
        selectionMark.SetActive(true);
    }
    public void OnDeselect()
    {
        selectionMark.SetActive(false);
    }
    public void Move(Vector3 targetPosition)
    {
        if (targetPosition == null) return;
        agent.SetDestination(targetPosition);
    }
}
