using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System;

public class PlanePositioning : MonoBehaviour 
{
	public MeshCollider ColliderForRayCast;
	public Transform Player;
	public Slider DurationSlider;
	public Slider EaseOvershootSlider;
	public DropDownList EaseType;
	public DropDownList EaseEquation;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (EventSystem.current.IsPointerOverGameObject(-1)) return;

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			ColliderForRayCast.Raycast(ray, out hitInfo, 100f);

			Ease ease = Ease.Linear;

			if (EaseType.SelectedItem != null && EaseEquation.SelectedItem != null)
				ease = (Ease) Enum.Parse(typeof(Ease), EaseType.SelectedItem.Caption + EaseEquation.SelectedItem.Caption);

			Player.DOMove(hitInfo.point, DurationSlider.value).SetEase(ease, EaseOvershootSlider.value);
		}
	}
}
