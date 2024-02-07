using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Characters.ThirdPerson;

public class NavMeshPlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;

	//SetDestination(position); input a position and our agent automatically just goes there via shortest path

	void Start()
	{
        agent.updateRotation = false;
	}

	// Update is called once per frame
	void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            { 
                // move our agent
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else 
        {
            character.Move(Vector3.zero, false, false);
        }
    }
}
