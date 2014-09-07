using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenadzerIgre : MonoBehaviour
{

    public static MenadzerIgre menadzerIgre;
    public float skretanje = 0f;
    public GameObject Igrac;
    public Text SkorLabela;
    public Text NajSkorLabela;

    public float Score = 0f;
    public static float HighScore = 0f;
    public float Brzina = 20f;

    private float Klizanje = 0f;
    private float strana = 0f;
    private float DozvoljenoKlizanje = 0f;
    
    private bool TiltKomande;
    private int PoeniPoMetru;
    private float PocetnaBrzina;
    private float PovecanjeBrzinePoSekundi;
    private float BrzinaKlizanja;
    private float VremeKlizanja;
    private float VremeZaKlizanje;
    private float VremeSmrti;

    void Start()
    {
        TiltKomande = PodesavanjaCuvanje.podesavanja.TiltKomande;
        PoeniPoMetru = PodesavanjaCuvanje.podesavanja.PoeniPoMetru;
        PocetnaBrzina = PodesavanjaCuvanje.podesavanja.PocetnaBrzina;
        VremeZaKlizanje = PodesavanjaCuvanje.podesavanja.VremeZaKlizanje;
        VremeSmrti = PodesavanjaCuvanje.podesavanja.VremeSmrti;
        UcitajPodesavanja();

        Brzina = PocetnaBrzina;
        HighScore = PlayerPrefs.GetFloat("HighScore");
        NajSkorLabela.text = "Najbolji rezultat: " + (int)HighScore;
        menadzerIgre = this;
    }

    void Update()
    {
        SkorLabela.text = "Rezultat: " + (int)Score;
        if (Igrac)
        {
            if (DozvoljenoKlizanje != 0)
            {
                if (DozvoljenoKlizanje > 0)
                    DozvoljenoKlizanje -= Time.deltaTime;
                else
                    DozvoljenoKlizanje = 0;
            }

            if (Klizanje != 0)
            {
                if (Klizanje > 0)
                    Klizanje -= Time.deltaTime;
                if (Klizanje < 0)
                    Klizanje = 0;
            }
            else
            {
                if (!TiltKomande)
                {
                    if (Input.touchCount > 0)
                    {
                        foreach (Touch touch in Input.touches)
                        {
                            if (touch.position.x < Screen.width / 2)
                            {
                                if (skretanje == 0 && strana == -1 && DozvoljenoKlizanje != 0)
                                {
                                    skretanje = -1 * BrzinaKlizanja;
                                    Klizanje = VremeKlizanja;
                                }
                                else
                                {
                                    skretanje = -1;
                                    DozvoljenoKlizanje = VremeZaKlizanje;
                                    strana = -1;
                                }
                            }
                            else
                            {
                                if (skretanje == 0 && strana == 1 && DozvoljenoKlizanje != 0)
                                {
                                    skretanje = BrzinaKlizanja;
                                    Klizanje = VremeKlizanja;
                                }
                                else
                                {
                                    skretanje = 1;
                                    DozvoljenoKlizanje = VremeZaKlizanje;
                                    strana = 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (skretanje == 0 && (skretanje = Input.GetAxis("Horizontal")) != 0 && skretanje == strana && DozvoljenoKlizanje != 0)
                        {
                            skretanje *= BrzinaKlizanja;
                            Klizanje = VremeKlizanja;
                        }
                        else
                        {
                            if ((skretanje = Input.GetAxis("Horizontal")) != 0)
                            {
                                DozvoljenoKlizanje = VremeZaKlizanje;
                                strana = skretanje;
                            }
                        }
                    }
                }
                else
                {
                    skretanje = Input.acceleration.x * 5;
                    if (Input.touchCount > 0)
                    {
                        if (Input.touches[Input.touchCount - 1].position.x < Screen.width / 2)
                        {
                            skretanje = -1 * BrzinaKlizanja;
                        }
                        else
                        {
                            skretanje = BrzinaKlizanja;
                        }
                        Klizanje = VremeKlizanja;
                    }
                }
            }

            Score += Brzina * Time.deltaTime * PoeniPoMetru;
            if (Brzina != 0)
                Brzina = Brzina + (PovecanjeBrzinePoSekundi * Time.deltaTime);
        }
        //ako ne nadje igraca onda je game over
        else
        {
            VremeSmrti -= Time.deltaTime;
            if (VremeSmrti <= 0)
            {
                VremeSmrti = 3f;
                PrekiniIgru(2);
            }
        }
    }

    public void UcitajPodesavanja()
    {
        PovecanjeBrzinePoSekundi = PodesavanjaCuvanje.podesavanja.PovecanjeBrzinePoSekundi;
        BrzinaKlizanja = PodesavanjaCuvanje.podesavanja.BrzinaKlizanja;
        VremeKlizanja = PodesavanjaCuvanje.podesavanja.VremeKlizanja;
    }
    public void PrekiniIgru(int VratiNa)
    {
        Time.timeScale = 1;
        PlayerPrefs.SetFloat("Score", Score);
        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetFloat("HighScore", HighScore);
        }
        Application.LoadLevel(VratiNa);
    }
}