using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public event Action<bool> IsGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Ground>(out Ground ground))
            IsGrounded?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Ground>(out Ground ground))
            IsGrounded?.Invoke(false);
    }
}
