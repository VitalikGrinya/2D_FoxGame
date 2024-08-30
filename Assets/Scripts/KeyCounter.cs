using TMPro;
using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _keyScore;
    [SerializeField] private KeyDetector _keyDetector;

    public int CurrentKeysCount { get; private set; } = 0;
    public int MaxKeysCount { get; private set; } = 5;

    private void OnEnable()
    {
        _keyDetector.GiveKey += TakeKey;
    }

    private void OnDisable()
    {
        _keyDetector.GiveKey -= TakeKey;
    }

    private void TakeKey()
    {
        CurrentKeysCount++;

        _keyScore.text = "Keys " + CurrentKeysCount.ToString() + "/5";
    }
}