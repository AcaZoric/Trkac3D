using UnityEngine;
using System.Collections;

public class Pojavljivanje : MonoBehaviour
{
    // ova skripta sluzi da se objekti polako pojavljuju u sceni
    public float vreme = 1f;
    public float minKrajnjaVisina = 1f;
    public float maxKrajnjaVisina = 10f;
    private Vector3 pocetnaVelicina;
  
	void Start () 
    {
        pocetnaVelicina = transform.localScale;
        StartCoroutine("Scale");
	}
	
	IEnumerator Scale()
    {
        float t = 0f;
        Vector3 Velicina = Vector3.one;
        Velicina.y = Random.Range(minKrajnjaVisina, maxKrajnjaVisina);
        while(t<= vreme)
        {
            transform.localScale = Vector3.Lerp(pocetnaVelicina, Velicina, t / vreme);
            t+=Time.deltaTime;
            yield return null;
        }

        transform.localScale = Velicina;
    }
}
