using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class BaseUnit : MonoBehaviour, ISelectable, IWalkable
{
    public int health;
    public float speed;
    public float range;

    [SerializeField] private GameObject selectionMark;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    public string currentAnimation = "Idle";

    void Start()
    {
        selectionMark = transform.GetChild(0).gameObject;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isMoving = agent.velocity.magnitude > 0.1f;

        if (isMoving && currentAnimation != "isMoving") OnMove();
        else if (!isMoving && currentAnimation != "isIdle") OnStop();
    }

    public void OnMove()
    {
        Debug.Log("Moving");
        ChangeAnimation("Walk");
    }
    public void OnStop()
    {
        ChangeAnimation("Idle");
    }

    private void ChangeAnimation(string animationName)
    {
        if (currentAnimation == animationName) return;
        currentAnimation = animationName;
        animator.CrossFade(animationName, 0.1f);
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
