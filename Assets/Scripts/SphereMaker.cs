using UnityEngine;
using Random = UnityEngine.Random;

public class SphereMaker : MonoBehaviour
{
	[SerializeField] private GameObject[] _initialSpheres;
	[SerializeField] private Transform[] _positions;
	[SerializeField] private Vector2 _periodRange;

	private float _period;

	private void Start()
	{
		Invoke("MakeSphere", Random.Range(_periodRange.x, _periodRange.y));
	}

	private void OnDestroy()
	{
		CancelInvoke();
	}

	private void MakeSphere()
	{
		var sphere = _initialSpheres[Random.Range(0, _initialSpheres.Length)];
		var pos = _positions[Random.Range(0, _positions.Length)];
		Instantiate(sphere, pos.localPosition, pos.localRotation).SetActive(true);
		Invoke("MakeSphere", Random.Range(_periodRange.x, _periodRange.y));
	}
}
