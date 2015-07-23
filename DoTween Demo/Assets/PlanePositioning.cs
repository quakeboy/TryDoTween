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
	public DropDownList EaseTypeX;
	public DropDownList EaseEquationX;
	public DropDownList EaseTypeY;
	public DropDownList EaseEquationY;

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

			//X Axis
			Ease easeX = Ease.Linear;

			if (EaseTypeX.SelectedItem != null && EaseEquationX.SelectedItem != null)
				easeX = (Ease) Enum.Parse(typeof(Ease), EaseTypeX.SelectedItem.Caption + EaseEquationX.SelectedItem.Caption);

			Player.DOMoveX(hitInfo.point.x, DurationSlider.value).SetEase(easeX, EaseOvershootSlider.value);

			//Y Axis
			Ease easeY = Ease.Linear;
			
			if (EaseTypeY.SelectedItem != null && EaseEquationY.SelectedItem != null)
				easeY = (Ease) Enum.Parse(typeof(Ease), EaseTypeY.SelectedItem.Caption + EaseEquationY.SelectedItem.Caption);

			//DoMoveZ because of the camera setup in 3D
			Player.DOMoveZ(hitInfo.point.z, DurationSlider.value).SetEase(easeY, EaseOvershootSlider.value);

		}
	}
}
