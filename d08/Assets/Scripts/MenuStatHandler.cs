using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuStatHandler : MonoBehaviour {

	[SerializeField]
	private	Canvas			menu;
	[SerializeField]
	private	GameObject		player;
	private Stat			playerStats;
	[SerializeField]
	private Text			str;
	[SerializeField]
	private Text			agi;
	[SerializeField]
	private Text			con;
	[SerializeField]
	private Text			pts;
	[SerializeField]
	private List<Button>	ups;
	/*
	[SerializeField]
	private Text			con;

*/
	void Start () {
		playerStats = player.GetComponent<Stat> ();
		str.text = "Stren. " + playerStats.STR.ToString ();
		agi.text = "Agility " + playerStats.AGI.ToString ();
		con.text = "Constit. " + playerStats.CON.ToString ();
		Debug.Log (playerStats.characs);
		pts.text = "UP Pts " + playerStats.characs.ToString ();

	}

	void checkRemainingPoints () {
		playerStats.characs--;
		pts.text = "UP Pts " + playerStats.characs.ToString ();
		if (playerStats.characs <= 0) {
			foreach (Button u in ups) {
				u.gameObject.SetActive(false);
			}
		}
	}

	public void exitMenu() {
		menu.enabled = false;
	}

	public void unpgradeStrength () {
		playerStats.STR++;
		str.text = "Stren. " + playerStats.STR.ToString ();
		checkRemainingPoints ();
	}

	public void unpgradeAgility () {
		playerStats.AGI++;
		agi.text = "Agility " + playerStats.AGI.ToString ();
		checkRemainingPoints ();
	}

	public void unpgradeConstitution () {
		playerStats.CON++;
		con.text = "Constit. " + playerStats.CON.ToString ();
		checkRemainingPoints ();
	}

}
