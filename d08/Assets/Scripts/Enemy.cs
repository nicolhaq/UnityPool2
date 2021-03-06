﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private GameObject		target = null;
	private NavMeshAgent	nav;
	private Animator		anim;
	private float			t0;
	private Stat			stats;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator>();
		nav.speed = 12;
		stats = GetComponent<Stat> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetBool ("dead")) {
			return;
		}

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
				}
				if (Time.time - t0 > 1f){
					stats.DealDamage(target);
					t0 = Time.time;
				}
			} else {
				anim.SetBool ("attacking", false);
			}
		}


		// /!\ Walk Annimation broken

		if (transform.position != nav.destination) {
			anim.SetBool ("running", true);
		} else {
			anim.SetBool ("running", false);
		}
		if (GetComponent<Stat>().HP <= 0 && !anim.GetBool("dead")) {
			anim.SetTrigger("death");
			anim.SetBool ("dead", true);
		}
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.gameObject.tag == "Player") {
			target = coll.gameObject;
		}
	}
}
