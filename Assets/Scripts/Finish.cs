using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private KeyCounter _counter;
    [SerializeField] private TMP_Text _winText;
    [SerializeField] private TMP_Text _continueText;
    [SerializeField] private Player _player;

    private string _sceneName = "SampleScene";

    private void Update()
    {
        Reset();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_counter.CurrentKeysCount == _counter.MaxKeysCount)
            {
                Destroy(collision.gameObject);

                _winText.text = "You Win";
                _continueText.text = "Press any key to continue";

                _winText.gameObject.SetActive(true);
                _continueText.gameObject.SetActive(true);
            }
        }
    }

    private void Reset()
    {
        if (_player == null && Input.anyKeyDown)
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
