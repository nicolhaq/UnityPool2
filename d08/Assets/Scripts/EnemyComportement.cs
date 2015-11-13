using UnityEngine;
using System.Collections;

public class EnemyComportement : MonoBehaviour {

	private int hp;
	public GameObject maya;
	private Animator	anim;

	// Use this for initialization
	void Start () {
		hp = 3;
		anim = GetComponent<Animator>();
	}

	public void setAttacked () {
		hp -= 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp == 0 && !anim.GetBool("dead")) {
			anim.SetTrigger("death");
			anim.SetBool ("dead", true);
		}
	}
}
