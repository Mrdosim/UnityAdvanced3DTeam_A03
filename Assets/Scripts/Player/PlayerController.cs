using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("Movement")]
	public float MoveSpeed;
	public float JumpPower;
	private Vector2 curMovementInput;
	public LayerMask groundLayerMask;

	[Header("Look")]
	public Transform CameraContainer;
	public float minXLook;
	public float maxXLook;
	private float camCurXRot;
	public float lookSensitivity;
	private Vector2 mouseDelta;
	public bool canLook = true;

	public Action inventory;
	private Rigidbody _rigidbody;
	public Action SettingEvents;
	public GameObject SettingPanel;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	// Start is called before the first frame update
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		SettingEvents += ToggleSetting;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Move();
	}

	private void LateUpdate()
	{
		if (canLook)
		{
			CameraLook();
		}
	}

	void Move()
	{
		Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
		dir *= MoveSpeed;
		dir.y = _rigidbody.velocity.y;

		_rigidbody.velocity = dir;
	}

	void CameraLook()
	{
		camCurXRot += mouseDelta.y * lookSensitivity;
		camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
		CameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

		transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity);
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		curMovementInput = context.ReadValue<Vector2>();
	}

	public void OnLook(InputAction.CallbackContext context)
	{
		mouseDelta = context.ReadValue<Vector2>();
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		if(context.phase == InputActionPhase.Started && IsGrounded())
		{
			_rigidbody.AddForce(Vector2.up * JumpPower, ForceMode.Impulse);
		}
	}

	bool IsGrounded()
	{
		Ray[] rays = new Ray[4]
		{
			new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
			new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
			new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
			new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
		};

		for(int i = 0; i < rays.Length; i++)
		{
			if (Physics.Raycast(rays[i], 0.5f, groundLayerMask))
			{
				return true;
			}
		}
		return false;
	}

	public void OnInventory(InputAction.CallbackContext context)
	{
		if(context.phase == InputActionPhase.Started)
		{
			inventory?.Invoke();
			ToggleCursor();
		}
	}
	
	public void OnSetting(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Started)
		{
			SettingEvents?.Invoke();
			ToggleCursor();
		}
	}

	void ToggleCursor()
	{
		bool toggle = Cursor.lockState == CursorLockMode.Locked;
		Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
		canLook = !toggle;
	}

	void ToggleSetting()
	{
		if (SettingPanel.activeInHierarchy)
		{
			SettingPanel.SetActive(false);
		}
		else
		{
			SettingPanel.SetActive(true);
		}
	}
}
