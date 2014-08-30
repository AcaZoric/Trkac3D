using UnityEngine;
using System.Collections;

public class Unistavanje : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
