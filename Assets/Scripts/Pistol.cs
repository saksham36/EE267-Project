using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Pistol : Weapon
{
    [SerializeField] private Projectile bulletPrefab;
    [SerializeField] private int ammo;


    public ReloadScreen reloadScreen;
    private int numBulletShot=0;

    private int messageTime = 2;


    protected override void StartShooting(XRBaseInteractor interactor)
    {
        base.StartShooting(interactor);
        Shoot();
    }

    protected override void Shoot()
    {
        if(numBulletShot < ammo)
        {
            numBulletShot += 1;
            base.Shoot();
            Projectile projectileInstance = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            projectileInstance.Init(this);
            audio.Play();
            projectileInstance.Launch();
            reloadScreen.Deactivate();
        }
        else
        {
            reloadScreen.Activate();
        }

    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
    }

    protected override void DropWeapon(XRBaseInteractor interactor)
    {
        DropGun();
        base.DropWeapon(interactor);
       
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
