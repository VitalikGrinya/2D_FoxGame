using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _waitValue;
    [SerializeField] private float _interpolationValue;

    private Slider _bar;
    private Coroutine _coroutine;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.ChangeHealth += SetSliderValue;
    }

    private void OnDisable()
    {
        _player.ChangeHealth -= SetSliderValue;
    }

    private void SetSliderValue()
    {
        _bar.maxValue = _player.MaxHealth;
        _bar.value = Mathf.Lerp(_bar.value, _player.CurrentHealth, _interpolationValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
            this.transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
            this.transform.parent = null;
    }
}
