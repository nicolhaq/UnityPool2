using UnityEngine;
using System.Collections;

public class EnemyComportement : MonoBehaviour {

	private Animator	anim;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {
		if (GetComponent<Stat>().HP == 0 && !anim.GetBool("dead")) {
			anim.SetTrigger("death");
			anim.SetBool ("dead", true);
		}
	}
}
