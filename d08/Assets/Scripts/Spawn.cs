using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject		zombie;

	private GameObject		_zombie;

	void Start () {
		_zombie = null;
	}

	void Update () {
		if (!_zombie)
			_zombie = (GameObject)Instantiate(zombie, transform.position, Quaternion.identity);
	}
}
