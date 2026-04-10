using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW2PowerUp : MonoBehaviour
{
    public GameObject preFab;
    public Transform bulletTrash;
    public Transform bulletSpawn;

    private const float Timer = 10f;
    private float _currentTime = 10f;
    private bool _canShoot = true;

    private void Update()
    {
        TimerMethod();
        Shoot();
    }

    private void TimerMethod()
    {
        if (!_canShoot)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime < 0)
            {
                _canShoot = true;
                _currentTime = Timer;
            }
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canShoot)
        {
            GameObject bullet = Instantiate(preFab, bulletSpawn.position, Quaternion.identity);

            bullet.transform.SetParent(bulletTrash);

            _canShoot = false;
        }
    }
}
