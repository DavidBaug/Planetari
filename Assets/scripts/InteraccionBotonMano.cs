using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionBotonMano : MonoBehaviour {
    public Camera cam;
    public AudioSource source;
    public AudioClip boton;
    private float velocidad;

    public Renderer lus;
//    public Renderer botonsito;
    public Material[] materiales;

    private bool encendido;
    
    // Use this for initialization
    void Start () {
        velocidad = 0;
        encendido = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Si el botón está activo cambiamos textura del pilotito de on/off
		if (encendido){
            lus.sharedMaterial = materiales[1];
            //botonsito.sharedMaterial = materiales[1];
        }else{
            //botonsito.sharedMaterial = materiales[0];
            lus.sharedMaterial = materiales[0];
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entramos en el Triger");
        //se ha metido, está pulsando el botón
        //source.PlayOneShot(boton, (float)0.6);
        //palante();

        

    }

    public void palante()
    {
        Debug.Log("Palante");

        //Establecemos velocidad y la aplicamos
        velocidad = (float)5;

        cam.transform.Translate(Vector3.forward * velocidad, Space.Self);

        
        

    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Estamos en el Triger");
        //se ha metido, está pulsando el botón
        palante();

        encendido = true;

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Pos nos vamos en el Triger");
        //se ha metido, está pulsando el botón
        //palante();

        encendido = false;

    }
}
