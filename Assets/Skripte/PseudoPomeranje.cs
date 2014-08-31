using UnityEngine;
using System.Collections;

public class PseudoPomeranje : MonoBehaviour
{
	void Update ()
    {
        renderer.material.mainTextureOffset += Vector2.up * (MenadzerIgre.menadzerIgre.Brzina/5) * Time.deltaTime;
        renderer.material.mainTextureOffset += Vector2.right * MenadzerIgre.menadzerIgre.skretanje * Time.deltaTime * (MenadzerIgre.menadzerIgre.Brzina / 10);
	}
}
