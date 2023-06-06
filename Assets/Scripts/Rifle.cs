using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Rifle : Weapon
{
    [SerializeField] private float fireRate;
    [SerializeField] private int ammo;
    public ReloadScreen reloadScreen;
    private Projectile projectile;
    private int numBulletShot=0;

    private int messageTime = 2;
    
    private WaitForSeconds wait;

    protected override void Awake()
    {
        base.Awake();
        projectile = GetComponentInChildren<Projectile>();
    }

    private void Start()
    {
        wait = new WaitForSeconds(1 / fireRate);
        projectile.Init(this);
    }

    protected override void StartShooting(XRBaseInteractor interactor)
    {
        base.StartShooting(interactor);
        StartCoroutine(ShootingCO());
    }

    private IEnumerator ShootingCO()
    {
        while (true)
        {
            Shoot();
            yield return wait;
        }
    }

    protected override void Shoot()
    {
        if(numBulletShot < ammo)
        {
            numBulletShot += 1;
            base.Shoot();
            projectile.Launch();
        }
        else
        {
            reloadScreen.Activate();
        }
        
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
        StopAllCoroutines();
    }

    protected override void DropWeapon(XRBaseInteractor interactor)
    {
        base.DropWeapon(interactor);
        DropGun();
    }
    protected override void DropGun()
    {
        reloadScreen.Deactivate();
    }
    IEnumerator reloadMessageWait()
    {
        yield return new WaitForSeconds(messageTime);
    }
}
