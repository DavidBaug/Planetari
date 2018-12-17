using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacionPlanetas : MonoBehaviour {

    public float rota_angle;
    public float rota_speed;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Planetas giran con un ángulo y velocidad determinados
        this.transform.Rotate(Vector3.up * rota_angle, Time.deltaTime * rota_speed);
    }
}
