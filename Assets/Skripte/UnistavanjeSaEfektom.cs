using UnityEngine;
using System.Collections;

public class UnistavanjeSaEfektom : MonoBehaviour
{
    //kada igrac udari negde unisti se i eksplodira
    public GameObject efekat;

    void OnTriggerEnter()
    {
        Instantiate(efekat, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
