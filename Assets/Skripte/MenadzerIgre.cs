using UnityEngine;
using System.Collections;

public class MenadzerIgre : MonoBehaviour 
{
    public static MenadzerIgre menadzerIgre;
    public float skretanje = 0f;
    public GameObject Igrac;
    public int PoeniPoMetru = 1;
    public float Brzina = 20f;
    private float Score = 0f;
    private static float HighScore = 0f;
    private bool krajIgre = false;
	
    void Start()
    {
        HighScore = PlayerPrefs.GetFloat("HighScore");
        menadzerIgre = this;
    }

    void Update()
    {
        if(!Igrac)
        {
            krajIgre = true;
            if (Score > HighScore)
            {
                HighScore = Score;
                PlayerPrefs.SetFloat("HighScore", HighScore);
            }
        }
        else 
        {
            Score += Brzina * Time.deltaTime * PoeniPoMetru;
        }

        if(krajIgre && Input.anyKeyDown)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.touchCount > 0)
        {
            skretanje = 0f;
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    skretanje -= 1;
                }
                else
                {
                    skretanje += 1;
                }
            }
        }
        else 
        {
            skretanje = Input.GetAxis("Horizontal");
        }
    }
    void OnGUI()
    {
        GUILayout.Label("Score: " + ((int)Score).ToString());
        GUILayout.Label("High score: " + ((int)HighScore).ToString());
        if(krajIgre == true)
        {
            GUILayout.Label("Kraj igre! pritisni bilo koje dugme za restart");
        }
    }
}
