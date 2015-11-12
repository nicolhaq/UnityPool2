using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public float distance  = 4.5f;
	public GameObject map;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		  if (Input.GetMouseButtonDown(0))
		 	GetComponent<NavMeshAgent>().destination = CastRayToWorld();
	}
	 Vector3 CastRayToWorld() {
     	Ray ray  = Camera.main.ScreenPointToRay(Input.mousePosition);    
    	 Vector3 point = ray.origin + (ray.direction * distance);    
    	 Debug.Log( "World point " + point );
    	 return(point);
 	}	
}
