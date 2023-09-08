using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameplayUI = null;
    [SerializeField] private GameObject _gameOverUI = null;
    [SerializeField] private TMP_Text _gameplayKillLabel = null;
    [SerializeField] private TMP_Text _gameOverKillLabel = null;


    private GameObject _player;
    private int _displayScore = -1;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (_player == null)
        {
            _gameplayUI.SetActive(false);
            _gameOverUI.SetActive(true);
            return;
        }
        _gameplayUI.SetActive(true);
        _gameOverUI.SetActive(false);

        if (_displayScore != PlayerScore.kills)
        {
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        _displayScore = PlayerScore.kills;
        _gameplayKillLabel.text = _displayScore.ToString();
        _gameOverKillLabel.text = string.Format("You have killed <color=green>{0}</color> monsters", _displayScore);
    }
}