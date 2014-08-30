using UnityEngine;
using System.Collections;

public class UnistavanjeSaEfektom : MonoBehaviour
{

    public GameObject efekat;

    void OnTriggerEnter()
    {
        Instantiate(efekat, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
