using System;
using UnityEngine;

public class KeyDetector : MonoBehaviour
{
    public event Action GiveKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Keys key))
        {
            GiveKey?.Invoke();
            key.gameObject.SetActive(false);
        }
    }
}
