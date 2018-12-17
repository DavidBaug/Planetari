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

    GameObject menusito;

    private double MAX = 0.20;
    public Camera cam;

    // Use this for initialization
    void Start()
    {
        controlador = new Controller();
        primero = controlador.Frame(); //inicializamos el Frame para tener el primer TimeStamp
        menuActivo = false;

        menusito = GameObject.Find("Menusito"); //buscamos el menú de los planetas

        menusito.transform.localPosition = new Vector3(6.7f, 3.1f, 4.94f); //lo inicializamos en la parte superior dela nave


    }

    // Update is called once per frame
    void Update()
    {
        Frame segundo = controlador.Frame(); //cogemos el Frame que llega
        //Controlamos los Frame para que no se sobresature de datos
        if (segundo.Timestamp - primero.Timestamp >= TIEMPO_MAX)
        {   //Si ha pasado un tiempo aceptable
            primero = segundo;
            //Vemos si tenemos algún movimiento que procesar
            activarMenu(segundo); 
            GirarCam(segundo);      
            RotarNave(segundo);
        }
    }

    void activarMenu(Frame fram)
    {
        if (fram.Hands.Count > 0 && fram.Hands.Count < 3)
        {   

            List<Hand> manos = fram.Hands;
            //buscamos las manos
            foreach (Hand mano in manos)
            {
                if (mano.IsLeft == true)
                {   //Este gesto es solo para la mano izquierda
                    if (mano.GrabAngle >= Mathf.PI) {
                        //Puño cerrado
                        menuActivo = true; //Para bloquear otros movimientos
                        Debug.Log("puño cerrado");
                        //Subimos el menú
                        menusito.transform.localPosition = new Vector3(6.7f, -1.52f, 4.94f);


                    }
                    else
                    {   //No bloqueamos otras opciones pues el puño está abierto
                        menuActivo = false;
                        Debug.Log("puño abierto");
                        //Se sube el menú porque se ha abierto el puño
                        menusito.transform.localPosition = new Vector3(6.7f, 3.1f, 4.94f);


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
                        {   //Este gesto es solo para la mano izquierda
                            

                            float ang_x = mano.Direction.Pitch;
                            float ang_normal = mano.Direction.Yaw;
                            float ang_z = mano.PalmNormal.Roll;

                            float ang = -1 * ang_normal * ang_x * (float)1.5;
                            //Cogemos el angulo que forma la mano


                            if (ang >= MAX || ang <= -MAX)
                            {
                                //Si la mano pasa de los límites
                                
                                //Rotamos la cámara a los lados, con una velocidad dependiendo del ángulo
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
                    
                    float ang_normal = mano.Direction.Yaw;
                    float ang_z = mano.PalmNormal.Roll;
                    
                    float ang = ang_normal * ang_z * (float)2;

                    //Cogemos el angulo que forma la mano

                    if (ang >= MAX || ang <= -MAX)
                    {
                        //Si la mano pasa de los límites
                        //Rotamos la cámara arriba/abajo con una velocidad dependiente del ángulo
                        cam.transform.Rotate(Vector3.up * ang, Space.Self);
                    }




                }
            }

        }

    }
}

