using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Здесь расписана логика, отвечающая за летающую пулю

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rg;
    [SerializeField] private float damage;

    float time = 0f;

    private void Update()
    {
        time += Time.deltaTime;
        time = Mathf.Clamp01(time);

        ProjMath.MoveTowardsAngleXZ(transform, transform.eulerAngles.y, speed * Time.deltaTime * time * time * time);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageble damageble))
        {
            Destroy(gameObject);
            damageble.GetDamage(damage);
        }
    }
}
