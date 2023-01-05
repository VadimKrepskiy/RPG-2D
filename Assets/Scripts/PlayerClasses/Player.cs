using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField] private GameObject deathMenu;
    [HideInInspector] public Vector3 currentDirection;
    protected Image healthBar;
    public Vector3 healthBarPostion;
    protected float healthBarLength;
    protected Text healthText;
    protected RangeController range;
    public bool OnMove { get; set; }
    protected override void Awake()
    {
        states = new List<State> { new PlayerIdleState(this), new PlayerMovingState(this) };
        OnMove = false;
        currentDirection = Vector3.zero;
        CurrentHealth = 100;
        maxHealth = CurrentHealth;
        base.Awake();
    }
    protected override void Start()
    {
        healthBar = GameObject.Find("Health").GetComponent<Image>();
        healthText = GameObject.Find("HealthPoints").GetComponent<Text>();
        healthBarLength = healthBar.rectTransform.rect.width;
        healthBarPostion = healthBar.transform.localPosition + Vector3.left*healthBarLength / 2;
        range=GetComponentInChildren<RangeController>();
        base.Start();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    protected override void Update()
    {
        base.Update();
    }
    public void SwitchState<T>() where T : PlayerState
    {
        var state = states.FirstOrDefault(s => s is T);
        SwitchState(state);
    }
    public void Move()
    {
        Move(currentDirection);
    }
    public override void GetDamage(int value)
    {
        base.GetDamage(value);
        var offset = healthBarLength * CurrentHealth / maxHealth; ;
        healthBar.transform.localPosition = healthBarPostion + Vector3.right*offset/2;
        healthBar.rectTransform.sizeDelta = new Vector2(offset, healthBar.rectTransform.rect.height);
        healthText.text = $"{CurrentHealth}/{maxHealth}";

    }
    public override IEnumerator Dead()
    {
        yield return base.Dead();
        deathMenu.transform.GetComponent<DeathMenuController>().Pause();
    }
    public void Attack()
    {
        Attack(range.target);
    }
}
