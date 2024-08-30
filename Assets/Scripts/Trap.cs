using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float _damageValue = 33.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damageValue);
        }
    }
}
