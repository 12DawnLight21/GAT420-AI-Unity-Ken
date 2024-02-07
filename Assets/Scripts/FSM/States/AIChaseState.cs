using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseState : AIState
{
	float initialSpeed;
	public AIChaseState(AIStateAgent agent) : base(agent)
	{
		AIStateTransition transition = new AIStateTransition(nameof(AIAttackState));
		transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
		transitions.Add(transition);

		transition = new AIStateTransition(nameof(AIIdleState));
		transition.AddCondition(new BoolCondition(agent.enemySeen, false));
		transitions.Add(transition);
	}

	public override void OnEnter()
	{
		agent.movement.Resume();
		initialSpeed = agent.movement.maxSpeed;
		agent.movement.maxForce += 2;
	}


	public override void OnUpdate()
	{
		// move towards enemy
		if (agent.enemySeen) agent.movement.Destination = agent.enemy.transform.position;

	}

	public override void OnExit()
	{
		agent.movement.maxSpeed = initialSpeed;
	}
}