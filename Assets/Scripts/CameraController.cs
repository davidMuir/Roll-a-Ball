using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{

	public GameObject Player;
	private Vector3 _offset;

	public void Start()
	{
		_offset = transform.position - Player.transform.position;
	}

	public void LateUpdate()
	{
		transform.position = Player.transform.position + _offset;
		transform.LookAt(Player.transform);
	}
}
