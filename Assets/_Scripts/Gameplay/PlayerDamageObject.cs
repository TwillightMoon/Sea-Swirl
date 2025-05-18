using UnityEngine;

public class PlayerDamageObject : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHPControler hp))
        {
            hp.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
