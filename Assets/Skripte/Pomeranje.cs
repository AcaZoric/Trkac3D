using UnityEngine;
using System.Collections;

public class Pomeranje : MonoBehaviour
{

	void Update ()
    {
        transform.position -= Vector3.forward * MenadzerIgre.menadzerIgre.Brzina*2 * Time.deltaTime;
        transform.position -= Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * MenadzerIgre.menadzerIgre.Brzina;
	}
}
