using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
    float timer;

    public AIIdleState(AIStateAgent agent) : base(agent)
    {
		AIStateTransition transition = new AIStateTransition(nameof(AIPatrolState));
		transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
        transitions.Add(transition);

        // reusing transition from above since its stored
        transition = new AIStateTransition(nameof(AIAttackState)); //make it chase state
        transition.AddCondition(new BoolCondition(agent.enemySeen));
        transitions.Add(transition);
    }

    public override void OnEnter()
    {
        agent.movement.Stop();
        agent.movement.Velocity = Vector3.zero;
        Debug.Log("Idle enter");

        agent.timer.value = Random.Range(1, 2);
        //timer = Time.time + Random.Range(1, 4);
    }

    public override void OnUpdate()
    {
        Debug.Log("Idle update");


        //if (transition.ToTransition()) agent.stateMachine.SetState(transition.nextState);
    }
    public override void OnExit()
    {
        Debug.Log("Idle exit");
    }
}
