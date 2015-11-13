﻿using UnityEngine;
using System.Collections;

public class Stat : MonoBehaviour {

	public int STR = 10;
	public int AGI = 10;
	public int CON = 10;
	public int Armor = 1;
	public int XP = 0;
	public int money;
	public int HP;
	public int level;
	public int characs;

	// Use this for initialization
	void Start () {
		level = 1;
		characs = 3;
		HP = maxHealth ();
	}

	public int maxHealth () {
		return (CON * 5);
	}

	public int minDamage () {
		return (STR / 2);
	}

	public int maxDamage () {
		return (minDamage() + 4);
	}

	public int expCap () {
		return (3000 * level);
	}

	public int 	Accuracy(Stat Target)
	{
		return(75 + AGI - Target.AGI);
	}

	public int baseDamage()
	{
		return(Random.Range(minDamage() , maxDamage()));
	}

	public int finalDamage(GameObject target)
	{

		 return(baseDamage() * (1 - target.GetComponent<Stat>().Armor/200));
	}

	// Update is called once per frame
	void Update () {
		if(XP >= expCap ())
		{
			level++;
			XP = 0;
		}
	}

	public void DealDamage(GameObject target) {
		Stat stat = target.GetComponent<Stat>();

		if(Random.Range(0, 100) <= Accuracy(stat))
		{
			stat.HP -= finalDamage(target);
			if (stat.HP <= 0) {
				XP += stat.XP;
				stat.XP = 0;
				money += stat.money;
				stat.money = 0;
			}
		}
	}

}
