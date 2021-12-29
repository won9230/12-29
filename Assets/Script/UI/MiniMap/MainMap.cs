using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMap : MonoBehaviour
{
	private RectTransform mainMap;
	private Vector2 mouseClickedPoition;

	public static MainMap instance = null;
	private void Awake() //싱글톤
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(this.gameObject);
	}
	private void Start()
	{
		mainMap = GetComponent<RectTransform>();
	}
	public Vector3 MainMapPosition()
	{
		mouseClickedPoition = Input.mousePosition;

		Vector2 clickedPosition = mouseClickedPoition - mainMap.offsetMin;

		Vector2 ratioVec = clickedPosition / mainMap.rect.size;

		Vector3 worldMapPosition;
		worldMapPosition.x = ratioVec.x * 300 +30;
		worldMapPosition.z = ratioVec.y * 300 +30;
		worldMapPosition.y = 0;

		return worldMapPosition;
	}
}
