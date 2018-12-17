using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

    public GameObject player;
    public AudioSource source;



    void OnTriggerEnter(Collider other)
    {
        //cuando se mete dentro del collider de un planeta
        Debug.Log("Entramos en el Triger");

    }

    public void explota()
    {
        Debug.Log("Explotó tu navecilla");
        source.Play();
        //Ponemos al jugador en otro punto
        player.transform.SetPositionAndRotation(new Vector3(-0.0f, 0.2260177f, -7596), new Quaternion(0.0f, 0.0f, 0.0f, 1));
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Estamos en el Triger");
        //está dentro del collider del planeta
        explota();
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Pos nos vamos en el Triger");
        
    }
}
