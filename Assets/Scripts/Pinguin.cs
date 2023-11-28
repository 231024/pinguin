using UnityEngine;
using UnityEngine.InputSystem;

public class Pinguin : MonoBehaviour
{
	[SerializeField] private float _movementSpeed;
	[SerializeField] private float _rotationSpeed;
	[SerializeField] private float _dashSpeed;
	[SerializeField] private float _jumpForce;
	[SerializeField] private Rigidbody _body;

	private DefaultInputActions _controls;

	public int CollectedPoints { get; private set; }

	private void Awake()
	{
		_controls = new DefaultInputActions();
		_controls.Player.Enable();
	}

	private void Update()
	{
		if (Mouse.current.leftButton.wasPressedThisFrame)
		{
			var hitInfo = new RaycastHit();
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hitInfo))
			{
				Debug.Log(hitInfo.collider.name);
			}
		}
	}

	private void FixedUpdate()
	{
		var move = _controls.Player.Move.ReadValue<Vector2>();
		_body.AddRelativeForce(new Vector3(0.0f, 0.0f, move.y) * _movementSpeed, ForceMode.VelocityChange);
		_body.AddTorque(new Vector3(0.0f, move.x, 0.0f) * _rotationSpeed);
	}

	private void OnCollisionEnter(Collision other)
	{
		var collisionSphere = other.gameObject.GetComponent<Sphere>();
		if (collisionSphere != null)
		{
			CollectedPoints += collisionSphere.Points;
		}
	}

	public void Jump(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			_body.AddForce(Vector3.up * _jumpForce);
		}
	}
}
