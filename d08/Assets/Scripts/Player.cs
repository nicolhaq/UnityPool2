﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	[SerializeField]
	private Canvas			menuXP;
	private NavMeshAgent	nav;
	private Animator		anim;
	private GameObject		target;

	public Slider			HpSlider;
	public Text				HPText;
	public Text				LvlText;
	public Text				Name;

	public GameObject		Panel;

	private RaycastHit		_rayHit;
	private Ray				_ray;
	private Stat			stats;

	private float			t0;


	void Start () {
		t0 = Time.time;
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator>();
		nav.speed = 8;
		target = null;
		stats = GetComponent<Stat> ();
	}

	void Update () {
		if (anim.GetBool ("dead")) {
			return;
		}

		//RAYCAST
		_ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(_ray.origin, _ray.direction * 10f, Color.red);

		if (Input.GetMouseButtonDown (0)) {
			// anim.SetBool ("attacking", false);
			if (Physics.Raycast(_ray, out _rayHit)) {
				Vector3		point = _rayHit.point;
				if (_rayHit.collider.gameObject.layer == LayerMask.NameToLayer("Zombie")) {
					target = _rayHit.collider.gameObject;
					nav.destination = target.transform.position;
				}
				else {
					nav.destination = point;
					target = null;
				}
			}
		}
		if (target) {
			//SLIDER
			Stat 		script;

			script = target.GetComponent<Stat> ();

			float hp = (float)script.HP / (float)script.maxHealth () * 100;
			HpSlider.GetComponent<Slider>().value = hp;
			HPText.GetComponent<Text> ().text = script.HP.ToString ();

			LvlText.GetComponent<Text>().text = "Lvl " + script.level;
			Name.GetComponent<Text>().text = "zombie";
			nav.destination = target.transform.position;
			Panel.SetActive(true);
		}
		else {
			Panel.SetActive(false);
		}

		//MOUVEMENTS
		if (target && Vector3.Distance(transform.position, target.transform.position) < 1.2f) {
			nav.destination = transform.position;
			Vector3 _direction = (target.transform.position - transform.position);
			transform.rotation = Quaternion.LookRotation(_direction);
			if (!anim.GetBool("attacking")) {
				anim.SetTrigger("attack");
				anim.SetBool ("attacking", true);
			}
			if (Time.time - t0 > 0.5f){
				stats.DealDamage(target);
				t0 = Time.time;
			}
		}
		if (transform.position != nav.destination) {
			anim.SetBool ("attacking", false);
			anim.SetBool ("running", true);
		} else {
			anim.SetBool ("running", false);
		}

		if (Input.GetKeyDown ("c")) {
			menuXP.gameObject.SetActive(true);
		}

		if (GetComponent<Stat>().HP <= 0 && !anim.GetBool("dead")) {
			anim.SetTrigger("death");
			anim.SetBool ("dead", true);
		}
	}

}
