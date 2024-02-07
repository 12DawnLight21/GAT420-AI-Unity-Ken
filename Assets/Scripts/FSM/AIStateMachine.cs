using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine
{
    private Dictionary<string, AIState> states = new Dictionary<string, AIState>();

    public AIState CurrentState { get; private set; } = null; // can set default values

    public void Update()
    { 
        CurrentState?.OnUpdate();
    }

    public void AddState(string name, AIState newState)
    {
        Debug.Assert(!states.ContainsKey(name), "State machine already contains state " + name);

        states[name] = newState;
    }

    public void SetState(string name)
    { 
        Debug.Assert(states.ContainsKey(name), "State machine doesn't contain state " + name);
        
        var nextState = states[name];

        // dont re-enter state
        if (CurrentState == nextState) return;

        // exit current state
        CurrentState?.OnExit();
        // set new state
        CurrentState = nextState;
        // enter new state
        CurrentState?.OnEnter();
    }
}
