﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Author: Namyoon Kim
 * 
 * This class manages to create pools for each registered prefabs.
 **/

[System.Serializable]
public class Item
{
	// register prefabs with quantities to be spawned, parent transformation,
	// and the prefab itself.
	public int quantity;
	public Transform parent;
	public GameObject prefab;
}

public class ObjectPooler : MonoBehaviour
{
	public List<Item> items;

	private void Awake ()
	{
		CreatePools ();	
	}

	private void CreatePools ()
	{
		for (int i = 0; i < items.Count; i++) {
			Item item = items [i];
			int quantity = item.quantity;
			Transform parent = item.parent;
			GameObject prefab = item.prefab;
			for (int j = 0; j < quantity; j++) {
				CreateItem (parent, prefab);
			}
		}
	}

	private void CreateItem (Transform parent, GameObject prefab)
	{
		GameObject item = Instantiate<GameObject> (prefab);
		item.transform.parent = parent.transform;
		item.SetActive (false);
	}
}