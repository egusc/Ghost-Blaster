using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlashEffect;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 0.2f;
    bool canShoot = true;

    private void OnEnable() {
        canShoot = true;
    }

    // void Update()
    // {
    //     if(Input.GetMouseButtonDown(0) && canShoot)
    //     {
    //         StartCoroutine(Shoot());
    //     } 
    // }

    // private IEnumerator Shoot()
    // {
    //     canShoot = false;
    //     if(ammoSlot.GetCurrentAmmo() > 0)
    //     {
    //         PlayMuzzleFlash();
    //         ProcessRaycast();
    //         ammoSlot.DecreaseAmmo();
    //     }

    //     yield return new WaitForSeconds(timeBetweenShots);
    //     canShoot = true;
        
    // }

    private void PlayMuzzleFlash()
    {
        muzzleFlashEffect.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target)
            {
                target.DamageEnemy(damage);
            }

            if (target == null) return;

        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}
