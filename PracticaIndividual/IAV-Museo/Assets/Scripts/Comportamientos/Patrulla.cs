/*    
   Copyright (C) 2020-2023 Federico Peinado
   http://www.federicopeinado.com
   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).
   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/

namespace UCM.IAV.Movimiento
{
    using System;
    using UCM.IAV.Navegacion;
    using UnityEngine;

    public class Patrulla: ComportamientoAgente
    {
        Transform sigNodo;

        public GuardiaGraph graph;
        public GuardiaGraph2 graph2;



        override public void Update()
        {
            if (graph == null && graph2==null)
            {
                if (this.gameObject.name == "Guardia0")
                {
                    Debug.Log("tengo0");
                    graph = GameObject.FindGameObjectWithTag("GuardiaGraph").GetComponent<GuardiaGraph>();
                }


                else if (this.gameObject.name == "Guardia1")
                {
                    Debug.Log("tengo1");
                    graph2 = GameObject.FindGameObjectWithTag("GuardiaGraph2").GetComponent<GuardiaGraph2>();
                }
            }
           
            if (graph != null||graph2!=null) { 
            //Si esta lo suficientemente cerca del nodo destino, lo elimina del camino en graph
                if (sigNodo != null && Vector3.Distance(transform.position, sigNodo.position) < 0.5f)
                {
                    if(graph!=null)
                    graph.PopLastNode();
                    else if(graph2!=null)
                    graph2.PopLastNode();
                }
                if (graph != null)
                {
                    sigNodo = graph.GetNextNode();
                }
                
                else if (graph2 != null)
                {
                    sigNodo = graph2.GetNextNode();
                }
                //Debug.Log(sigNodo);
            }

           
            base.Update();
        }

        public override Direccion GetDireccion()
        {
            Direccion direccion = new Direccion();

            if (sigNodo != null)
            {
                //Direccion actual
                direccion.lineal = sigNodo.position - transform.position;
            }
            else
            {
                direccion.lineal = new Vector3(0, 0, 0);
            }

            //Resto de cálculo de movimiento
            direccion.lineal.Normalize();
            direccion.lineal *= agente.aceleracionMax;

            // Podríamos meter una rotación automática en la dirección del movimiento, si quisiéramos

            return direccion;
        }

        public void ResetPath()
        {
            if (graph != null)
            {
                graph.ResetPath();
            }
            else if (graph2 != null)
            {
                graph2.ResetPath();
            }
           
        }
    }
}