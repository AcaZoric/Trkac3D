using UnityEngine;
using System.Collections;

public class MenadzerIgre : MonoBehaviour 
{
    public static MenadzerIgre menadzerIgre;
    public GameObject Igrac;
    public int PoeniPoMetru = 1;
    public float Brzina = 20f;
    private float Score = 0f;
    private bool krajIgre = false;
	
    void Start()
    {
        menadzerIgre = this;
    }
    void Update()
    {
        if(!Igrac)
        {
            krajIgre = true;
        }
        else 
        {
            Score += Brzina * Time.deltaTime * PoeniPoMetru;
        }

        if(krajIgre && Input.anyKeyDown)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

    }
    void OnGUI()
    {
        GUILayout.Label("Score: " + ((int)Score).ToString());
        if(krajIgre == true)
        {
            GUILayout.Label("Kraj igre! pritisni bilo koje dugme za restart");
        }
    }
}
