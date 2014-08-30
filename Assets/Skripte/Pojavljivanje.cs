using UnityEngine;
using System.Collections;

public class Pojavljivanje : MonoBehaviour
{
    public float vreme = 1f;
    public Vector3 krajnjaVelicina = Vector3.zero;
    private Vector3 pocetnaVelicina;
  
	void Start () 
    {
        pocetnaVelicina = transform.localScale;
        StartCoroutine("Scale");
	}
	
	IEnumerator Scale()
    {
        float t = 0f;

        while(t<= vreme)
        {
            transform.localScale = Vector3.Lerp(pocetnaVelicina, krajnjaVelicina, t / vreme);
            t+=Time.deltaTime;
            yield return null;
        }

        transform.localScale = krajnjaVelicina;
    }
}
