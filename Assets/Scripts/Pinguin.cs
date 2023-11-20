using UnityEngine;

public class Pinguin : MonoBehaviour
{
	[SerializeField] private float _movementSpeed;
	[SerializeField] private float _rotationSpeed;
	[SerializeField] private float _dashSpeed;
	[SerializeField] private float _jumpForce;
	[SerializeField] private Rigidbody _body;

	public int CollectedPoints { get; private set; }

	private void Update()
	{
		// var hitInfo = new RaycastHit();
		// if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
		// {
		// 	Debug.Log(hitInfo.collider.name);
		// }

		if (Input.GetKeyDown(KeyCode.Space))
		{
			_body.AddForce(Vector3.up * _jumpForce);
		}

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			_body.AddRelativeForce(Vector3.forward * _dashSpeed, ForceMode.Impulse);
		}
	}

	private void FixedUpdate()
	{
		_body.AddRelativeForce(new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical")) * _movementSpeed, ForceMode.VelocityChange);
		_body.AddTorque(new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f) * _rotationSpeed);
	}

	private void OnCollisionEnter(Collision other)
	{
		var collisionSphere = other.gameObject.GetComponent<Sphere>();
		if (collisionSphere != null)
		{
			CollectedPoints += collisionSphere.Points;
		}
	}
}
