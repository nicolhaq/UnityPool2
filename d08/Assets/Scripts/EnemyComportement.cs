using UnityEngine;
using System.Collections;

public class EnemyComportement : MonoBehaviour {

	public int hp;
	public GameObject maya;
	private Animator	anim;

	// Use this for initialization
	void Start () {
		hp = 3;
		anim = GetComponent<Animator>();
	}

	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Stat>().HP == 0 && !anim.GetBool("dead")) {
			anim.SetTrigger("death");
			anim.SetBool ("dead", true);
		}
	}
}
