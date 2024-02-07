using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHitState : AIState
{
	public AIHitState(AIStateAgent agent) : base(agent)
	{
	}

	public override void OnEnter()
	{
		AIStateTransition transition = new AIStateTransition(nameof(AIIdleState));
		transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
		transitions.Add(transition);
	}
	public override void OnUpdate()
	{
		
	}

	public override void OnExit()
	{
		
	}


}
