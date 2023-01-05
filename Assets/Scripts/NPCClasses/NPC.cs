using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPC : Character
{
    public GameObject PlayerObject { get; private set; }
    public Player player { get; private set; }
    public  List<Vector2> path;
    public int CurrentPoint { get; protected set; } = 0;
    public int PrevPoint{ get; protected set; } = 0;
    protected override void Awake()
    {
        states = new List<State> { new NPCPatrollingState(this), new NPCPursuitState(this), new NPCDeathState(this) };
        CurrentHealth = 50;
        maxHealth = CurrentHealth;
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        player= PlayerObject.GetComponent<Player>();
    }
    public void SwitchState<T>() where T : NPCState
    {
        var state = states.FirstOrDefault(s => s is T);
        SwitchState(state);
    }
    public void SwitchPoint()
    {
        ++CurrentPoint;
        if (CurrentPoint > path.Count - 1)
        {
            CurrentPoint = 0;
        }
        PrevPoint = CurrentPoint;
    }
    public override IEnumerator Dead()
    {
        SwitchState<NPCDeathState>();
        yield return base.Dead();
        Destroy(gameObject);
    }
}
