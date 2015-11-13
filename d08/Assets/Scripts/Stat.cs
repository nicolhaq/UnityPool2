using UnityEngine;
using System.Collections;

public class Stat : MonoBehaviour {

	public int STR = 10;
	public int AGI = 10;
	public int CON = 10;
	public int Armor = 1;
	public int minDamage;
	public int maxDamage;
	public int XP = 0;
	public int money;
	public int HP;
	private int level;
	private int expCap;

	// Use this for initialization
	void Start () {
		HP = CON * 5;
		minDamage = STR / 2;
		maxDamage = maxDamage + 4;
		level = 1;
		expCap = 3000 * level;

	}

	public int 	Accuracy(Stat Target)
	{
		return(75 + AGI - Target.AGI);
	}

	public int baseDamage()
	{
		return(Random.Range(minDamage , maxDamage));
	}

	public int finalDamage(Stat Target)
	{
		 return(baseDamage() * (1 - Target.Armor/200));
	}

	// Update is called once per frame
	void Update () {
	}
}
