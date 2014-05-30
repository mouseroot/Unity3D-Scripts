using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
Object Pooling tutorial here
https://www.youtube.com/watch?v=9-zDOJllPZ8

IMPORTANT: The bullet prebab must have the bullet.cs script to work properly
 */

public class ObjectPooling : MonoBehaviour {

	public GameObject bullet;// The object to be pooled
	public int listSize = 0; // size of the pool
	public bool isListExpandable = true; // if more objects are required

	private List<GameObject> objectList; // the list to store the objects

	void Awake(){
		objectList = new List<GameObject>();
		// Initialise all the objects in the pool
		for(int i = 0; i < listSize; i++){
			GameObject obj = (GameObject)Instantiate(bullet);
			obj.SetActive(false);
			objectList.Add(obj);
		}
	}

	// Change the update function to suit your game
	void Update(){
		if(Input.GetButtonDown("Jump")){
			Invoke("Fire",1f);
		}
	}

	// Instantiates the objects, it does not move the bullet
	public void Fire(){
		bool isObjectAvailable = false;
		// Checks for an inactive gameobject and activates it
		foreach(GameObject temp in objectList){ 
			if(!temp.activeInHierarchy){
				isObjectAvailable = true;
				temp.transform.position = transform.position;
				temp.transform.rotation = transform.rotation;
				temp.SetActive(true);
				break;
			}			
		}
		// if there is no active game object AND the list is expandable,
		// then expands the list
		if(!isObjectAvailable && isListExpandable){ 
			GameObject obj = (GameObject)Instantiate(bullet);
			obj.transform.position = transform.position;
			obj.transform.rotation = transform.rotation;
			objectList.Add(obj);
			obj.SetActive(true);
		}
	}

}
