using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotator : MonoBehaviour
{
    [SerializeField] private float minRandomRotateValue = -180;
    [SerializeField] private float maxRandomRotateValue = 181;

    private CircleRotatorConfig config;
    private IEnumerator circleRotator;
    private Transform myTransform;
    private CircleRotatorRandomizer rotateRandomizer;

    private void Awake()
    {
        myTransform = GetComponent<Transform>();
    }

    private void OnDisable()
    {
        rotateRandomizer?.Unscribe();
    }

    public void StartInitialize(CircleRotatorConfig c)
    {
        config = c;
        rotateRandomizer = new CircleRotatorRandomizer(config);

        rotateRandomizer.Subscribe();

        if (circleRotator == null)
        {
            circleRotator = Rotate();
            StartCoroutine(circleRotator);
        }
        else
        {
            StopCoroutine(circleRotator);
            StartCoroutine(circleRotator);
        }
        GetRandomRotate();
    }

    private void GetRandomRotate()
    {
        myTransform.Rotate(0f, 0f,Random.Range(minRandomRotateValue, maxRandomRotateValue));
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            int rotateDir = config.dir == EDirection.Clockwise ? 1 : -1;
            myTransform.Rotate(0f, 0f, config.rotateSpeed * rotateDir * Time.deltaTime);
            yield return null;
        }
    }
}
