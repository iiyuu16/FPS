using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 75f;
    public float fireRate = 1f;
    float nextFire;
    public Camera fpsCam;
    public ParticleSystem bulletFX;
    public ParticleSystem muzzleFX;

    [Header("Recoil Settings")]
    public float recoilAmount = 0.1f;
    public float recoilSpeed = 5.0f;
    public float recoilReturnSpeed = 2.0f;
    public float maxRecoilOffset = 0.3f; // Maximum recoil offset to prevent the gun from moving too far down

    private Vector3 originalPosition;
    private Vector3 recoilOffset;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }

        ApplyRecoil();
    }

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            bulletFX.Play();
            muzzleFX.Play();

            // Apply recoil
            recoilOffset += new Vector3(Random.Range(-recoilAmount, recoilAmount), -recoilAmount, 0);
            recoilOffset.y = Mathf.Clamp(recoilOffset.y, -maxRecoilOffset, 0); // Clamp the recoil to not exceed maxRecoilOffset

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();

                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }

    private void ApplyRecoil()
    {
        // Smoothly return to the original position with recoil offset
        recoilOffset = Vector3.Lerp(recoilOffset, Vector3.zero, recoilReturnSpeed * Time.deltaTime);
        transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition + recoilOffset, recoilSpeed * Time.deltaTime);
    }
}
