using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateSlider : MonoBehaviour {

	public Slider		HpSlider;
	public Slider		XpSlider;

	void Update () {
		HpSlider.GetComponent<Slider>().value = GetComponent(Stat).HP;
		XpSlider.GetComponent<Slider>().value = GetComponent(Stat).XP;
	}
}
