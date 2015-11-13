using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private Canvas			menuXP;
	private NavMeshAgent	nav;
	private Animator		anim;
	private GameObject		target;

	private RaycastHit		_rayHit;
	private Ray				_ray;
	private Stat			stats;

	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator>();
		nav.speed = 8;
		target = null;
		stats = GetComponent<Stat> ();
	}

	void Update () {


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
		if (target)
			nav.destination = target.transform.position;

		//MOUVEMENTS
		if (target && Vector3.Distance(transform.position, target.transform.position) < 1.2f) {
			nav.destination = transform.position;
			Vector3 _direction = (target.transform.position - transform.position);
			transform.rotation = Quaternion.LookRotation(_direction);
			if (!anim.GetBool("attacking")) {
				anim.SetTrigger("attack");
				anim.SetBool ("attacking", true);
				stats.DealDamage(target);
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
	}

}
