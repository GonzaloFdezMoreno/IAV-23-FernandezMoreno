using System.Collections;
using System.Collections.Generic;
using UCM.IAV.Movimiento;
using UnityEngine;

public class VistaObj : MonoBehaviour
{

    //private Merodear mero;
    private Patrulla reco;
    private Llegada lleg;
    
    [SerializeField]
    Transform objTransform;
    
    RaycastHit sightObj = new RaycastHit();

   
    float angvistaObj; //para ver si el guardia ve el objeto

    // Start is called before the first frame update
    void Awake()
    {
        //mero = GetComponent<Merodear>();
        reco = GetComponent<Patrulla>();
        lleg = GetComponent<Llegada>();
       
        objTransform = GameManager.instance.GetObj().transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GuardiaHasObj())
        {
            if (!GameManager.instance.GetSeek())
            {
                if (Physics.Raycast(transform.position, objTransform.position - transform.position, out sightObj)) //creamos una linea entre el objeto y el guardia
                {


                    angvistaObj = Vector3.Angle(transform.forward, objTransform.position - transform.position);
                    Debug.Log(sightObj.collider.gameObject.name);

                    if (sightObj.collider.gameObject.name == "ExitSlab" && angvistaObj > -30 && angvistaObj < 30 && !GameManager.instance.ObjOnInitialPos()) //si ve que el objeto no esta en su sitio ir� hacia el
                    {

                        if (!lleg.enabled)
                        {
                            //si lo ve que vaya a por el
                            reco.enabled = false;
                            lleg.enabled = true;
                            lleg.objetivo = sightObj.collider.gameObject;
                            GameManager.instance.Keep();

                        }
                    }
                    else
                    {
                        if (!reco.enabled)
                        { //para que solo lo haga 1 vez
                          //si no lo ve que siga merodeando
                            reco.enabled = true;
                            lleg.enabled = false;
                            reco.ResetPath();
                            GameManager.instance.StopKeep();

                        }
                    }
                }
            }
        }

        else
        {
            if (!reco.enabled)
            { //para que solo lo haga 1 vez
              //si no lo ve que siga merodeando
                reco.enabled = true;
                lleg.enabled = false;
                GameManager.instance.StopKeep();

            }
        }
       

    }

}

