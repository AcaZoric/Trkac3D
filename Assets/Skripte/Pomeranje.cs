using UnityEngine;
using System.Collections;

public class Pomeranje : MonoBehaviour
{
    //uzina brzinu i skretanje iz skripte menadzerIgre objekta MenagerIgre i na osnovu njih pomera objekte
	void Update ()
    {
        transform.position -= Vector3.forward * MenadzerIgre.menadzerIgre.Brzina*2 * Time.deltaTime;
        transform.position -= Vector3.right * MenadzerIgre.menadzerIgre.skretanje * 0.5f * Time.deltaTime * MenadzerIgre.menadzerIgre.Brzina;
        if (transform.position.z <= -10)//ako objekti izadju 'iza' ekrana unistavaju se
            Destroy(gameObject);
	}
}
