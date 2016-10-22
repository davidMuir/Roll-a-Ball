using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public float Speed;
	private Rigidbody _rigidBody;
	private int _count = 0;
	public Text CountText;
	public Text WinText;

	public void Start()
	{
		_rigidBody = GetComponent<Rigidbody>();
		UpdateCountText();
		WinText.text = string.Empty;
	}

	public void FixedUpdate()
	{
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		var movement = new Vector3(moveHorizontal, 0, moveVertical);

		_rigidBody.AddForce(movement * Speed);
	}

	public void OnTriggerEnter(Collider other)
	{
		if (!other.gameObject.CompareTag("Pickup")) return;

		other.gameObject.SetActive(false);
		_count++;
		UpdateCountText();
	}

	private void UpdateCountText()
	{
		var remaining = GameObject.FindGameObjectsWithTag("Pickup").Length; 

		CountText.text = $"Count: {_count}";
		
		if (remaining > 0) return;

		WinText.text = "You Win!";
	}
}
