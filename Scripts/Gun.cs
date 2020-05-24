using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    private Text AmmoText;
    float bulletForce = 10;
    int shootingSeries = 1;

    float nextFire = 0.05f;

    WeaponSwitching a;

    private static int ammo;

    public void addToAmmo(int val)
    {
        ammo += val;
        AmmoText.text = "x" + ammo.ToString("00");
    }

    // Start is called before the first frame update
    void Start()
    {
        ammo = 5;
        a = GameObject.Find("WeaponHolder").GetComponent<WeaponSwitching>();

        AmmoText = GameObject.Find("AmmoText").GetComponent<Text>();
        AmmoText.text = "x" + ammo.ToString("00");

    }



    public void EditWeapon()
    {
        if (a.selectedWeapon == 0)
        {
            shootingSeries = 1;
            bulletForce = 20;
        }
        else
        {
            shootingSeries = 3;
            bulletForce = 30;
        }
    }

    public void Shoot()
    {
        EditWeapon();

        if (a.selectedWeapon == 1)
        {
            ShootRifle();
           
        }
        else
            ShootPistol();


    }

    void ShootRifle()
    {


        for (int i = 0; i < shootingSeries; i++)
        {
            if (ammo > 0)
            {
                
                Invoke("CreateBullet", 0.1f + nextFire * i);
                
            }
        }
        if (ammo > 0)
            ammo--;
        AmmoText.text = "x" + ammo.ToString();
    }

    void ShootPistol()
    {
        CreateBullet();
    }   

    void CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);
       
    }

}

