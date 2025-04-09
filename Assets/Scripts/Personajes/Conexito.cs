using UnityEngine;

public class Conexito : MainPersonaje
{
    public bool gafasEntregadas;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gafasEntregadas = true;
        }
    }
}
