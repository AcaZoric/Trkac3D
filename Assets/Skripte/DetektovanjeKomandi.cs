using UnityEngine;
using System.Collections;

public class DetektovanjeKomandi : MonoBehaviour
{
	void Update ()
    {
        //detektovanje klika misa
	    if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("Pogodjen je: " + hit.collider.name, hit.collider.gameObject);
            }
        }

        //detektovanje touch klika
       foreach(Touch touch in Input.touches)
       {
           Ray ray = Camera.main.ScreenPointToRay((Vector3)touch.position);
           
           RaycastHit hit;

           if (Physics.Raycast(ray, out hit))
           {
               Debug.Log("Pogodjen je: " + hit.collider.name, hit.collider.gameObject);
           }
       }
	}
}
