using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float			distance  = 4.5f;
	public GameObject 		map;
	private NavMeshAgent	nav;
	private Animator		anim;
	private GameObject		target;
	
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator>();
		nav.speed = 8;
		target = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray			ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3		point = ray.origin + (ray.direction * distance);
			RaycastHit	hit;

			anim.SetBool ("attacking", false);
			if (Physics.Raycast(ray, out hit)) {
				if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Zombie")) {
					target = hit.collider.gameObject;
					nav.destination = target.transform.position;
				} else {
					nav.destination = point;
					target = null;
				}
			}
		}
		if (target && Vector3.Distance(transform.position, target.transform.position) < 3) {
			if (!anim.GetBool("attacking")) {
				anim.SetTrigger("attack");
				anim.SetBool ("attacking", true);
			}
		}
		if (transform.position != nav.destination) {
			anim.SetBool ("running", true);
		} else {
			anim.SetBool ("running", false);
		}
	}

}
