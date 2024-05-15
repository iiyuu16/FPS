using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 75f;
    public Camera fpsCam;
    public ParticleSystem bulletFX;
    public ParticleSystem muzzleFX;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
            bulletFX.Play();
            muzzleFX.Play();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }
            

        }
    }
}
