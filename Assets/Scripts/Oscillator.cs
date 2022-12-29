using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    
    
    void Start()
    {
        startingPosition = transform.position;
    }

    
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;  // zaman içerisinde sürekli büyümeyi ifade eder
        
        const float tau = Mathf.PI * 2;  // tau, sabit değer: 6.283
        float rawSinWave = Mathf.Sin(cycles * tau);  // sinüs fonsiyonu gibi -1 ile 1 arasında 

        movementFactor = (rawSinWave + 1f) / 2f; 
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
