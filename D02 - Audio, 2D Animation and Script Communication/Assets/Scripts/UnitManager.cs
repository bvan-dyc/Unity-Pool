using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {
	public Color selectionTint;
	public Unit	unitPrefab;
	public bool canInteract = true;
	private List<Unit> Units = new List<Unit>();

	void Update () {
		if (canInteract && Input.GetMouseButtonDown(0))
		{
			OnMouseDown();
		}
		if (canInteract && Input.GetMouseButtonDown(1))
		{
			foreach (Unit v in Units)
			{
				v.selected = 0;
				v.GetComponent<SpriteRenderer>().color = Color.white;
			}
		}
	}

	public void spawnUnit(Vector3 newPosition)
	{
		unitPrefab.transform.position = newPosition;
		Units.Add(Instantiate(unitPrefab));
	}

	private void OnMouseDown()
	{
		RaycastHit2D hit;
		var ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (hit = Physics2D.Raycast (ray, transform.position)) {
			foreach (Unit u in Units) {
				if (hit.collider.gameObject == u.gameObject)
				{
					if (!(Input.GetKey(KeyCode.LeftControl)))
					{
						foreach (Unit v in Units)
						{
							v.selected = 0;
							v.GetComponent<SpriteRenderer>().color = Color.white;
						}
					}
					u.selected = 2;
					u.GetComponent<SpriteRenderer>().color = selectionTint;
				}
			}
		}
	}
}
