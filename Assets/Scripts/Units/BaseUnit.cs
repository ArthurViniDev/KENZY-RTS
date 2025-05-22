using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class BaseUnit : MonoBehaviour, ISelectable, IWalkable
{
    [Header("Unit Stats")]
    public int health;
    //public float range;

    public bool isAttacking = false;
    public GameObject Target { get; set; }

    [SerializeField] protected float stopDistance = 1.0f;
    private GameObject selectionMark;
    private NavMeshAgent agent;
    private Animator animator;

    private IAnimationController animationController;

    public void SetState(string state) => animationController.ChangeAnimation(state);

    public void SetSelection(bool state) => selectionMark.SetActive(state);

    private void Start()
    {
        animator = GetComponent<Animator>();
        animationController = new AnimationController(animator, "Idle");
        selectionMark = transform.GetChild(0).gameObject;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        HandleUnitState();
    }

    private void HandleUnitState()
    {
        HandleAttackState();
        HandleMovementState();
    }

    private void HandleAttackState()
    {
        if (Target)
        {
            var distance = Vector3.Distance(transform.position, Target.transform.position);
            else
            {
                agent.isStopped = true;
                OnAttack();
            }
        }
        else if (!Target && isAttacking) EndAttack();
    }

    private void HandleMovementState()
    {
        if (isAttacking) return;

        var isMoving = agent.velocity.magnitude > 0.1f;

        SetState(isMoving ? "Walk" : "Idle");
    }

    public virtual void OnAttack()
    {
        SetAttackState(true);
        animationController.ChangeAnimation("Attack");

        var lookDirection = Target.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), Time.deltaTime * 5f);
    }

    public virtual void EndAttack() => SetAttackState(false);

    private void SetAttackState(bool attacking)
    {
        isAttacking = attacking;
        if(!attacking)Target = null;
    }

    public void Move(Vector3 targetPosition)
    {
        agent.isStopped = false;
        agent.SetDestination(targetPosition);
    }
}

public class AnimationController : IAnimationController
{
    private readonly Animator animator;
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