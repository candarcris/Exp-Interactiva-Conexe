using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Camera cam;
    public GameObject mirilla;
    public Transform pc;
    public Transform mapa;
    public Transform cuadroHonor;
    public Transform puertaOfice;
    public Transform puertaLab;
    public static bool pcElegido;


    void Awake() 
    {
        cam = GetComponent<Camera>();
        pcElegido = false;
    }

    // Update is called once per frame
    void Update()
    {
        mirilla.SetActive(true);

        pc.GetComponent<Interactuar>().ActivarAura(true);
        mapa.GetComponent<InteractuarMapa>().ActivarAura(true);
        cuadroHonor.GetComponent<InteractuarCuadroHonor>().ActivarAura(true);
        //puertaOfice.GetComponent<InteractuarPuertaOfice>().ActivarAura(true);
        //puertaLab.GetComponent<InteractuarPuertaLab>().ActivarAura(true);

        Ray rayo = cam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
        RaycastHit hit = new RaycastHit();
        Debug.DrawRay (rayo.origin, rayo.direction, Color.red);
        if(Physics.Raycast(rayo, out hit))
        {
            var selection = hit.transform;
            if(selection == pc)
            {
                //pc.GetComponent<Interactuar>().ActivarAura(true);
                mapa.GetComponent<InteractuarMapa>().ActivarAura(false);
                cuadroHonor.GetComponent<InteractuarCuadroHonor>().ActivarAura(false);
                puertaOfice.GetComponent<InteractuarPuertaOfice>().ActivarAura(false);
                puertaLab.GetComponent<InteractuarPuertaLab>().ActivarAura(false);
            }
            if(selection == mapa)
            {
                //mapa.GetComponent<InteractuarMapa>().ActivarAura(true);
                pc.GetComponent<Interactuar>().ActivarAura(false);
                cuadroHonor.GetComponent<InteractuarCuadroHonor>().ActivarAura(false);
                puertaOfice.GetComponent<InteractuarPuertaOfice>().ActivarAura(false);
                puertaLab.GetComponent<InteractuarPuertaLab>().ActivarAura(false);
            }
            if(selection == cuadroHonor)
            {
                //cuadroHonor.GetComponent<InteractuarCuadroHonor>().ActivarAura(true);
                mapa.GetComponent<InteractuarMapa>().ActivarAura(false);
                pc.GetComponent<Interactuar>().ActivarAura(false);
                puertaOfice.GetComponent<InteractuarPuertaOfice>().ActivarAura(false);
                puertaLab.GetComponent<InteractuarPuertaLab>().ActivarAura(false);
            }
            if(selection == puertaOfice)
            {
                puertaOfice.GetComponent<InteractuarPuertaOfice>().ActivarAura(true);
                puertaLab.GetComponent<InteractuarPuertaLab>().ActivarAura(false);
                cuadroHonor.GetComponent<InteractuarCuadroHonor>().ActivarAura(false);
                mapa.GetComponent<InteractuarMapa>().ActivarAura(false);
                pc.GetComponent<Interactuar>().ActivarAura(false);
            }
            if(selection == puertaLab)
            {
                puertaLab.GetComponent<InteractuarPuertaLab>().ActivarAura(true);
                puertaOfice.GetComponent<InteractuarPuertaOfice>().ActivarAura(false);
                cuadroHonor.GetComponent<InteractuarCuadroHonor>().ActivarAura(false);
                mapa.GetComponent<InteractuarMapa>().ActivarAura(false);
                pc.GetComponent<Interactuar>().ActivarAura(false);
            }
            if(Input.GetMouseButtonDown(0))
            {
                if(selection.GetComponent<Interactuar>() != null)
                {
                    selection.GetComponent<Interactuar>().OnLookEnter();
                }
                if(selection.GetComponent<InteractuarPuertaLab>() != null)
                {
                    selection.GetComponent<InteractuarPuertaLab>().OnLookEnter();
                }
                if(selection.GetComponent<InteractuarPuertaOfice>() != null)
                {
                    selection.GetComponent<InteractuarPuertaOfice>().OnLookEnter();
                }
                if(selection.GetComponent<InteractuarMapa>() != null)
                {
                    selection.GetComponent<InteractuarMapa>().OnLookEnter();
                }
                if(selection.GetComponent<InteractuarCuadroHonor>() != null)
                {
                    selection.GetComponent<InteractuarCuadroHonor>().OnLookEnter();
                }
            }
        }
    }
}
