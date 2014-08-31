using UnityEngine;
using System.Collections;

public class MenadzerIgre : MonoBehaviour 
{
    public static MenadzerIgre menadzerIgre;
    public float skretanje = 0f;
    public GameObject Igrac;
    public int PoeniPoMetru = 1;
    public float PocetnaBrzina = 20f;
    public float Brzina = 20f;
    public float PovecanjeBrzinePoSekundi = 1f;
    private float Score = 0f;
    private static float HighScore = 0f;
    private float VremeSmrti = 1.5f;

    void Start()
    {
        Brzina = PocetnaBrzina;
        HighScore = PlayerPrefs.GetFloat("HighScore");
        menadzerIgre = this;
    }

    void Update()
    {
        if(!Igrac)
        {
            if (Input.anyKeyDown && VremeSmrti <= 0)
            {
                VremeSmrti = 3f;
                Application.LoadLevel(Application.loadedLevel);
            }
            VremeSmrti -= Time.deltaTime;

            if (Score > HighScore)
            {
                HighScore = Score;
                PlayerPrefs.SetFloat("HighScore", HighScore);
            }
        }
        else 
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.position.x < Screen.width / 2)
                    {
                        skretanje = 1;
                    }
                    else
                    {
                        skretanje = 1;
                    }
                }
            }
            else
            {
                skretanje = Input.GetAxis("Horizontal");
            }

            Score += Brzina * Time.deltaTime * PoeniPoMetru;
            Brzina=Brzina+(PovecanjeBrzinePoSekundi*Time.deltaTime);
        }

    }
    void OnGUI()
    {
        GUILayout.Label("Score: " + ((int)Score).ToString());
        GUILayout.Label("High score: " + ((int)HighScore).ToString());
        if(!Igrac == true)
        {
            GUILayout.Label("Kraj igre!" + (VremeSmrti<=0 ? " Pritisni bilo koje dugme za restart." : ""));
        }
    }
}
