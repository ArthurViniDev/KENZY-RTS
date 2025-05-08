using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class BaseUnit : MonoBehaviour, ISelectable, IWalkable
{
    [Header("Unit Stats")]
    public int health;
    public float range;

    public bool isAttacking = false;
    public GameObject target { get; set; }

    [SerializeField] private float stopDistance = 1.0f;
    private GameObject selectionMark;
    private NavMeshAgent agent;
    private Animator animator;

    protected IAnimationController animationController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animationController = new AnimationController(animator, "Idle");
        selectionMark = transform.GetChild(0).gameObject;
        agent = GetComponent<NavMeshAgent>();
    }

    public virtual void Update()
    {
        if (target && !isAttacking)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance <= stopDistance)
            {
                agent.isStopped = true;
                OnAttack();
            }
        }
        else if (!target && isAttacking) OnEndAttack();

        if (isAttacking) return;

        bool isMoving = agent.velocity.magnitude > 0.1f;

        if (isMoving) SetState("Walk");
        else SetState("Idle");
    }

    public void SetState(string state) => animationController.ChangeAnimation(state);

    public void SetSelection(bool state) => selectionMark.SetActive(state);

    public virtual void OnAttack()
    {
        isAttacking = true;
        animationController.ChangeAnimation("Attack");

        Vector3 lookDirection = (target.transform.position - transform.position);
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
    public virtual void OnEndAttack()
    {
        target = null;
        isAttacking = false;
    }

    public void Move(Vector3 targetPosition)
    {
        agent.isStopped = false;
        agent.SetDestination(targetPosition);
    }
}

public class AnimationController : IAnimationController
{
    private Animator animator;
    private string currentAnimation;

    public AnimationController(Animator animator, string currentAnimation = "")
    {
        this.currentAnimation = currentAnimation;
        this.animator = animator;
    }

    public void ChangeAnimation(string animationName)
    {
        if (currentAnimation == animationName) return;
        currentAnimation = animationName;
        animator.CrossFade(animationName, 0.1f);
    }
}