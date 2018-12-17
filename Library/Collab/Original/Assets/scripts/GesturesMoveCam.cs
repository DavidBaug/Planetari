using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class GesturesMoveCam : MonoBehaviour
{
    Frame primero;
    Controller controlador;
    bool menuActivo;
    public float TIEMPO_MAX = 100;

    private double MAX = 0.20;
    public Camera cam;

    // Use this for initialization
    void Start()
    {
        controlador = new Controller();
        primero = controlador.Frame();
        menuActivo = false;

    }

    // Update is called once per frame
    void Update()
    {
        Frame segundo = controlador.Frame();
        //Controlamos los Frame para que no se sobresature de datos
        if (segundo.Timestamp - primero.Timestamp >= TIEMPO_MAX)
        {
            primero = segundo;
            activarMenu(segundo);
            GirarCam(segundo);
            RotarNave(segundo);
        }
    }

    void activarMenu(Frame fram)
    {
        if (fram.Hands.Count > 0)
        {

            List<Hand> manos = fram.Hands;
            //buscamos las manos
            foreach (Hand mano in manos)
            {
                if (mano.IsLeft == true)
                {   //Este gesto es solo para la mano izquierda
                    if (mano.GrabAngle >= Mathf.PI) { 
                        menuActivo = true;
                        Debug.Log("puño cerrado");
                    }
                    else
                    {
                        menuActivo = false;
                        Debug.Log("puño abierto");
                    }
                }
            }
        }
    }
    

    void RotarNave(Frame fram){

        if (fram.Hands.Count == 2 )
                {
                    
                    List<Hand> manos = fram.Hands;
                    //buscamos las manos
                    foreach (Hand mano in manos)
                    {
                        if (mano.IsLeft == true && !menuActivo)
                        {   //Este gesto es solo para la mano derecha

                            float ang_x = mano.Direction.Pitch;
                            float ang_normal = mano.Direction.Yaw;
                            float ang_z = mano.PalmNormal.Roll;

                            float ang = -1 * ang_normal * ang_x * (float)1.5;
                            //Cogemos el angulo que forma la mano


                            if (ang >= MAX || ang <= -MAX)
                            {
                                //Si la mano pasa de los límites
                                //float ang_velo = ang * (float)2;
                                //Rotamos la cámara a los lados dependiendo, con una velocidad dependiendo del ángulo
                                cam.transform.Rotate(Vector3.right * ang, Space.Self);
                            }


                        }
                    }

            }
    }

    void GirarCam(Frame fram)
    {

        if (fram.Hands.Count == 2)
        {
            List<Hand> manos = fram.Hands;
            //buscamos las manos
            foreach (Hand mano in manos)
            {
                if (mano.IsLeft != true && !menuActivo)
                {   //Este gesto es solo para la mano derecha
                    
                    float ang_x = mano.Direction.Pitch;
                    float ang_normal = mano.Direction.Yaw;
                    float ang_z = mano.PalmNormal.Roll;
                    
                    float ang = ang_normal * ang_z * (float)2;

                    //float ang = ang_normal * ang_z;
                    //Cogemos el angulo que forma la mano

                    if (ang >= MAX || ang <= -MAX)
                    {
                        //Si la mano pasa de los límites
                        //Rotamos la cámara a los lados dependiendo, con una velocidad dependiendo del ángulo
                        cam.transform.Rotate(Vector3.up * ang, Space.Self);
                    }




                }
            }

        }

    }
}

