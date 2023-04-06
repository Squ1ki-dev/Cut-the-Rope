using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RopeCutter : MonoBehaviour 
{
	Rigidbody2D rb2d;
	Camera cam;

	void Start()
	{
       rb2d = GetComponent<Rigidbody2D>();
	   cam = Camera.main;
	}

	private void Update() 
	{
		Cut();
	}

	private void Cut()
	{
		if (Input.GetMouseButton(0))
		{
			Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
			rb2d.position = mousePosition;

			RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject.CompareTag("Link"))
			{
				Destroy(hit.collider.gameObject);
				foreach (Transform child in hit.transform.parent)
				{
					var renderer = child.GetComponent<Renderer>();
					if (child != hit.transform)
						renderer.material.DOFade(0f, 1f).OnComplete(() => Destroy(child.gameObject, 0.5f));
				}
			}
		}
	}
}
