/*    
   Copyright (C) 2020-2023 Federico Peinado
   http://www.federicopeinado.com
   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Inform�tica de la Universidad Complutense de Madrid (Espa�a).
   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/

namespace UCM.IAV.Movimiento
{
    using System;
    using UCM.IAV.Navegacion;
    using UnityEngine;

    public class SeguirCamino: ComportamientoAgente
    {
        Transform sigNodo;

        public TheseusGraph graph;

        override public void Update()
        {
            //Si esta lo suficientemente cerca del nodo destino, lo elimina del camino en graph
            if (sigNodo != null && Vector3.Distance(transform.position, sigNodo.position) < 0.5f)
            {
                graph.PopLastNode();
            }
            sigNodo = graph.GetNextNode();
            //Debug.Log(sigNodo);
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

            //Resto de c�lculo de movimiento
            direccion.lineal.Normalize();
            direccion.lineal *= agente.aceleracionMax;

            // Podr�amos meter una rotaci�n autom�tica en la direcci�n del movimiento, si quisi�ramos

            return direccion;
        }

        public void ResetPath()
        {
            graph.ResetPath();
        }
    }
}