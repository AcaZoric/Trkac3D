using UnityEngine;
using System.Collections;

public class Pomeranje : MonoBehaviour
{

	void Update ()
    {
        transform.position -= Vector3.forward * MenadzerIgre.menadzerIgre.Brzina*2 * Time.deltaTime;
        transform.position -= Vector3.right * MenadzerIgre.menadzerIgre.skretanje * 0.5f * Time.deltaTime * MenadzerIgre.menadzerIgre.Brzina;
        if (transform.position.z <= -10)
            Destroy(gameObject);
	}
}
