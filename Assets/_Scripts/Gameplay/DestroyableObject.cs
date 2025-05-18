using UnityEngine;

public interface IDamageble
{
    void GetDamage(float damage);
}

public class DestroyableObject : MonoBehaviour, IDamageble
{
    [SerializeField] private float hp;

    public void GetDamage(float damage)
    {
        hp -= damage;
    }

    private void Update()
    {
        if (hp <= 0f) Destroy(gameObject);
    }
}
