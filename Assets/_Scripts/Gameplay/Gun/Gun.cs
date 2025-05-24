using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private int ammo;

    public void Shoot()
    {
        if (ammo <= 0) return;
        ammo--;

        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    public void LoadAmmo(int count = 1)
    {
        ammo += count;
    }
}
