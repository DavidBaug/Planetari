using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class NaveMovimiento : MonoBehaviour {
	
	public AudioClip boton;

	private float velocidad;
	public AudioSource source;

    public Camera cam;

	// Use this for initialization
	void Start () {
		velocidad = 0; //inicializamos a 0

	}
	
	// Update is called once per frame
	void Update () {
            //hacemos que se mueva 
			cam.transform.Translate(Vector3.forward * velocidad, Space.Self);

	}

	public void palante(){
        //se mueve hacia delante
        //Ponemos sonido
		source.PlayOneShot(boton,(float)0.6);
		//
		velocidad = (float)0.9;
        //le damos velocidad
		

	}


	
	public void noCambio(){
				velocidad = (float)0;

	}

}
