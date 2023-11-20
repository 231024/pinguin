using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private const string MainSceneName = "NatureScene";
	[SerializeField] private Pinguin _pinguin;
	[SerializeField] private Chicken _chicken;
	[SerializeField] private int _pointsCount;
	[SerializeField] private float _roundTime;

	[Header("UI")] [SerializeField] private TMP_Text _playerPointsText;
	[SerializeField] private TMP_Text _timerText;
	[SerializeField] private TMP_Text _playerResultText;
	[SerializeField] private TMP_Text _chickenResultText;
	[SerializeField] private GameObject _gameOverPanel;

	private void Update()
	{
		_roundTime -= Time.deltaTime;

		if (_roundTime <= 0.0f)
		{
			ShowResultScreen();
			return;
		}

		_timerText.SetText($"{_roundTime:00.0}");

		if (_pinguin.CollectedPoints >= _pointsCount || _chicken.CollectedPoints >= _pointsCount)
		{
			ShowResultScreen();
			return;
		}

		_playerPointsText.SetText(_pinguin.CollectedPoints.ToString());
	}

	private void ShowResultScreen()
	{
		_playerResultText.SetText(_pinguin.CollectedPoints.ToString());
		_chickenResultText.SetText(_chicken.CollectedPoints.ToString());
		_gameOverPanel.SetActive(true);
	}

	public void OnStartNewGameClick()
	{
		SceneManager.LoadScene(MainSceneName);
	}
}
