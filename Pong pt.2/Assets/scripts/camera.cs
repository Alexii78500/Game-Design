using UnityEngine;

public class Camera : MonoBehaviour
{
    private static float shakeTime = 0;
    public static float shakeAmount = 0.7f;
    private float decreaseFactor = 1f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeTime > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount * shakeTime;
            shakeTime -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeTime = 0f;
            transform.localPosition = originalPosition;
        }
    }

    public static void StartShake(float duration, float amount)
    {
        if (shakeTime == 0)
        {
            shakeTime = duration;
            shakeAmount = amount;
        }
    }
}