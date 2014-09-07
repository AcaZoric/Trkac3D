using UnityEngine;
using System.Collections;

public class RotiranjeKamerePoTiltu : MonoBehaviour
{
    private float prosliput;
    private bool Dozvoljeno;

    void Start()
    {
        Dozvoljeno = PodesavanjaCuvanje.podesavanja.TiltVirtualni;
        prosliput = 0;
    }

    void Update()
    {
        if (Dozvoljeno)
        {
            transform.Rotate(0, 0, -(Input.acceleration.x - prosliput)*20);
            prosliput = Input.acceleration.x;
        }
    }
}
