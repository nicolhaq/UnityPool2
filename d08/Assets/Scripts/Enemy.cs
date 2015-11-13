using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private GameObject		target = null;
	private NavMeshAgent	nav;
	private Animator		anim;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator>();
		nav.speed = 12;
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			nav.destination = target.transform.position;
			if (Vector3.Distance(transform.position, target.transform.position) < 3) {
				if (!anim.GetBool("attacking")) {
					anim.SetTrigger("attack");
					anim.SetBool ("attacking", true);
					//target.GetComponent<EnemyComportement>().setAttacked();
				}
			} else {
				anim.SetBool ("attacking", false);
			}
		}
		if (transform.position != nav.destination) {
			anim.SetBool ("running", true);
		} else {
			anim.SetBool ("running", false);
		}
	}

	/*
	void OnTriggerEnter (Collider coll) {
		Debug.Log (coll.gameObject.tag + " detected");
	}*/

	void OnTriggerStay (Collider coll) {
		if (coll.gameObject.tag == "Player") {
			target = coll.gameObject;
		}
	}

	void OnTriggerLeave (Collider coll) {
		if (coll.gameObject.tag == "Player") {
			target = null;
		}
	}

}
