using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    protected List<State> states;
    protected State currentState;
    protected Rigidbody2D rigidBody2D;
    protected Vector3 startScale;
    private int _currentHealth;
    protected int maxHealth;
    protected bool isAlive = true;
    protected bool isCanAttack = true;
    public bool IsAlive { get; private set; } = true;
    public int CurrentHealth
    {
        get => _currentHealth;
        protected set => _currentHealth = (value > 0) ? value :  0;
    }
    public Animator animator { get; protected set; }
    protected virtual void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startScale = transform.localScale;
    }
    protected virtual void Start()
    {
        currentState = states[0];
    }
    protected virtual void FixedUpdate()
    {
        currentState.FixedUpdate();
    }
    protected virtual void Update()
    {
        currentState.Update();
    }
    public void Move(Vector3 direction)
    {
        if (direction.x < 0)
            transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
        else if (direction.x > 0) transform.localScale = startScale;
        rigidBody2D.velocity = direction.normalized*moveSpeed;
    }
    protected void SwitchState(State state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }

    public virtual void GetDamage(int value)
    {
        if (isAlive)
        {
            CurrentHealth -= value;
            animator.SetTrigger("Hurt");
            if (CurrentHealth == 0)
            {
                isAlive = false;
                StartCoroutine(Dead());
            }
        }
    }
    public virtual IEnumerator Dead()
    {
        animator.SetBool("Death", true);
        yield return new WaitForSeconds(2f);
        //yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
    }
    public void Attack(Character enemy)
    {
        if (isCanAttack)
        {
            animator.SetTrigger("Attack");
            StartCoroutine(Attack(1.5f, enemy));
        }
    }
    IEnumerator Attack(float second, Character enemy)
    {
        isCanAttack = false;
        yield return new WaitForSeconds(.25f);
        enemy?.GetDamage(10);
        yield return new WaitForSeconds(second);
        isCanAttack = true;
    }
}
