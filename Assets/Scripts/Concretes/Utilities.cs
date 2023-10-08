using UnityEngine;

public static class Utilities
{
    public static bool HasTypeCollider<T, K>(ref T _collider, out K _type) where T : Collider2D where K : MonoBehaviour
    {
        return _collider.TryGetComponent(out _type);
    }
    public static bool HasTypeCollision<T, K>(ref T _collision, out K _type) where T : Collision2D where K : MonoBehaviour
    {
        return _collision.gameObject.TryGetComponent(out _type);
    }
}