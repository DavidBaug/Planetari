using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translacionPlanetas : MonoBehaviour {

    public float vel_trans;
    public GameObject Punto_Mira;
	// Use this for initialization
	void Start () {
        //vel_trans = 10;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mi_punto = Punto_Mira.transform.position; 
        this.transform.RotateAround(mi_punto,Vector3.up, vel_trans * Time.deltaTime);
    }
}
