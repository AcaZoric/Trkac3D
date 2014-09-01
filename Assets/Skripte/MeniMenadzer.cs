using UnityEngine;
using System.Collections;

public class MeniMenadzer : MonoBehaviour
{

	public void UcitajNivo(int Nivo)
    {
        Application.LoadLevel(Nivo);
    }

    public void IzadjiIzIgre()
    {
        Application.Quit();
    }
}
