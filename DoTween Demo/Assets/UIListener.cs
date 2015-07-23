using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class UIListener : MonoBehaviour 
{
	public Slider DurationSlider;
	public Slider EaseOverShootSlider;
	public Text DurationText;
	public Text EaseOverShootText;
	
	public void DurationChanged(float value)
	{
		DurationText.text = "Duration " + String.Format("{0:0.00}", DurationSlider.value);
		EaseOverShootText.text = "Ease Overshoot " + String.Format("{0:0.00}", EaseOverShootSlider.value);
	}
}