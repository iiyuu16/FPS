using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.1f;
    public float shakeMagnitude = 0.1f;
    public float dampingSpeed = 1.0f;

    private Vector3 initialPosition;
    private float shakeTimeRemaining;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        if (shakeTimeRemaining > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeTimeRemaining -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeTimeRemaining = 0;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake()
    {
        shakeTimeRemaining = shakeDuration;
    }
}
