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

		//ATTACK player
		if (target) {
			nav.destination = target.transform.position;
			Vector3 _direction = (target.transform.position - transform.position);
			transform.rotation = Quaternion.LookRotation(_direction);
			if (Vector3.Distance(transform.position, target.transform.position) < 1.2f) {
				nav.destination = transform.position;
				if (!anim.GetBool("attacking")) {
					anim.SetTrigger("attack");
					anim.SetBool ("attacking", true);
					//target.GetComponent<EnemyComportement>().setAttacked();
				}
			} else {
				anim.SetBool ("attacking", false); // <----- /!\
				// anim.SetBool ("attacking", true);
			}
		}


		// /!\ Walk Annimation broken

		// if (transform.position != nav.destination) {
		// 	anim.SetBool ("running", true);
		// } else {
		// 	anim.SetBool ("running", false);
		// }
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.gameObject.tag == "Player") {
			target = coll.gameObject;
		}
	}
}
