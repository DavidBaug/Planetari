using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using UnityEngine.Video;
using UnityEngine.UI;

public class Videos : MonoBehaviour {

	public VideoPlayer player;
    public VideoClip[] clips;

	void Awake(){
        //Por defecto ponemos el video de inicio
		player = GetComponent<VideoPlayer> ();
		player.clip = clips[1];
		player.Play();
	}


	public void ponerVideo(int videoNum){
        //Paramos el que tenemos reproduciendo
		player.Stop();
        //Ponemos el que nos mandan y lo reproducimos
		player.clip = clips[videoNum];
		player.Play();
	}

	void playVideo(){
        //Reproducir video
		player.Play();
	}

	void pauseVideo(){
        //Pausar video
		player.Pause();
	}

}
