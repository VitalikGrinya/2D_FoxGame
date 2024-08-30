using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField] private Transform _respPoint;
    [SerializeField] private float _damageValue = 50f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.transform.position = _respPoint.position;
            player.TakeDamage(_damageValue);
        }
    }
}
