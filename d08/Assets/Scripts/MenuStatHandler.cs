using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuStatHandler : MonoBehaviour {

	[SerializeField]
	private	Canvas			menu;
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
	int	s, a, c, p;

	void Start () {
		s = 10;
		a = 12;
		c = 15;
		p = 3;
		str.text = "Stren. " + s.ToString ();
		agi.text = "Agility " + a.ToString ();
		con.text = "Constit. " + c.ToString ();
		pts.text = "UP Pts " + p.ToString ();

	}

	void checkRemainingPoints () {
		p--;
		pts.text = "UP Pts " + p.ToString ();
		if (p <= 0) {
			foreach (Button u in ups) {
				u.gameObject.SetActive(false);
			}
		}
	}

	public void exitMenu() {
		menu.enabled = false;
	}

	public void unpgradeStrength () {
		s++;
		str.text = "Stren. " + s.ToString ();
		checkRemainingPoints ();
	}

	public void unpgradeAgility () {
		a++;
		agi.text = "Agility " + a.ToString ();
		checkRemainingPoints ();
	}

	public void unpgradeConstitution () {
		c++;
		con.text = "Constit. " + c.ToString ();
		checkRemainingPoints ();
	}

}
