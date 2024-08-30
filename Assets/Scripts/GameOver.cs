using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _loseText;
    [SerializeField] private TMP_Text _restartText;

    private string _sceneName = "SampleScene";

    private void Update()
    {
        Lose();
    }

    private void Lose()
    {
        if (_player.CurrentHealth == 0)
        {
            _player.gameObject.SetActive(false);

            _loseText.text = "You Lose";
            _restartText.text = "Press any key to continue";

            _loseText.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);

            Reset();
        }
    }

    private void Reset()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
