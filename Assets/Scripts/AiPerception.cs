using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiPerception : MonoBehaviour
{
	[SerializeField] string tagName = "";
	[SerializeField] float distance = 1;
	[SerializeField] float maxAngle = 45;
	[SerializeField] protected LayerMask layerMask = Physics.AllLayers;

	public string TagName { get { return tagName; } }
	public float Distance { get { return distance; } }
	public float MaxAngle { get { return maxAngle; } }


	public abstract GameObject[] GetGameObjects();
}
