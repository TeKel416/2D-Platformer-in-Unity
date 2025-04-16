using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	//checa objetos que entraram no portal
	private HashSet <GameObject> portalObjects = new HashSet<GameObject>();

	[SerializeField] private Transform destination;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//previne que o objeto entre infinitamente nos portais
		if (!collision.CompareTag("Player"))
		{
			return;
		}
		if (destination.TryGetComponent(out Portal destinationPortal))
		{
			destinationPortal.portalObjects.Add(collision.gameObject);
		}
		collision.transform.position = destination.position;
		}

			private void OnTriggerExit2D(Collider2D collision)
		{
		if (!collision.CompareTag("Player"))
		{
			return;
		}
	portalObjects.Remove(collision.gameObject);
	}
}