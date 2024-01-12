using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDistancePerception : AiPerception
{
    public override GameObject[] GetGameObjects()
    {
        // list of objects we've seen
        List<GameObject> result = new List<GameObject>();

        
        Collider[] colliders = Physics.OverlapSphere(transform.position, Distance);
        foreach (Collider collider in colliders)
        {
            // checks if collision is itself, skip if so
            if (collider.gameObject == gameObject) continue;
            if (TagName == "" || collider.CompareTag(TagName))
            {
                // calculate angle from transform forward vector to direction of game object
                Vector3 direction = (collider.transform.position - transform.position).normalized;
                float angle = Vector3.Angle(transform.forward, direction);
                // if angle is less than max angle, add game object
                if (angle <= MaxAngle)
                {
                    result.Add(collider.gameObject);
                }
            }
        }

        return result.ToArray();
    }
}
