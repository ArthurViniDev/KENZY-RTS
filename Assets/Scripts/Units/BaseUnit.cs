using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class BaseUnit : MonoBehaviour, ISelectable, IWalkable
{
    public int health;
    public float range;

    [SerializeField] private GameObject selectionMark;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    private IAnimationController animationController;
    void Start()
    {
        animator = GetComponent<Animator>();
        animationController = new AnimationController(animator, "Idle");
        selectionMark = transform.GetChild(0).gameObject;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        bool isMoving = agent.velocity.magnitude > 0.1f;

        if (isMoving) OnMove();
        else OnStop();
    }

    public void OnMove()
    {
        animationController.ChangeAnimation("Walk");
    }

    public void OnStop()
    {
        animationController.ChangeAnimation("Idle");
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
