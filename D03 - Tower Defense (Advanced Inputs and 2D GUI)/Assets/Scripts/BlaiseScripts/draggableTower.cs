using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class draggableTower : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public GameObject itemToDrag;
	public towerScript tower;
	public bool canDrag = true;

	public gameManager manager;

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (canDrag)
		{
			itemToDrag = Instantiate(gameObject, transform);
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (canDrag)
		{
			itemToDrag.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (canDrag)
		{
			if (itemToDrag != null)
			{
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
				if (hit && hit.collider.transform.tag == "empty")
				{
					manager.playerEnergy -= tower.energy;
					Instantiate(tower, hit.collider.gameObject.transform.position, Quaternion.identity);
				}
				Destroy(itemToDrag);
				itemToDrag = null;
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (manager.playerEnergy - tower.energy < 0)
		{
			canDrag = false;
			GetComponent<Image>().color = Color.gray;
		}
		else
		{
			canDrag = true;
			GetComponent<Image>().color = Color.white;
		}
	}
}
