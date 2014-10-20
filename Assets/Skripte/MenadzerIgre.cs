using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenadzerIgre : MonoBehaviour
{

    public static MenadzerIgre menadzerIgre;
    public GameObject Igrac;
    public Text SkorLabela;
    public Text NajSkorLabela;
    public float skretanje = 0f;//ova promenljiva mora da postoji i bude public jer je koristi PseudoPomeranje... 

    public float Score = 0f;
    public static float HighScore = 0f;
    public float Brzina = 20f;

    private float Klizanje = 0f;//tacnije uzima vrednost od promenljive VremeKlizanja kad pocne klizanje, i onda je smanjuje i klizanje prestaje kad se smanji na 0 
    private float strana = 0f;//sluzi za proveru na koju stranu je igrac poslednju isao, tako da ako dva puta brzo klikne na istu stranu moze da se aktivira klizanje
    private float DozvoljenoKlizanje = 0f;//uzima vrednost 0 ako klizanje nije dozvoljeno sluzi kao tajmer za dupli klik
    
    private bool TiltKomande;// ako je true onda je dozvoljeno kretanje koriscenjem "tilta"
    private int PoeniPoMetru;
    private float PocetnaBrzina;
    private float PovecanjeBrzinePoSekundi;//ubrzanje
    private float BrzinaKlizanja;//brzina kojom igrac klize levo i desno duplik klikom, ili obicnim klikom ako su tilt komande
    private float VremeKlizanja;//trajanje klizanja
    private float VremeZaKlizanje;//brzina kojom treba kliknuti da bi se prepoznao dupli klik
    private float VremeSmrti;//vreme koje protekne od smrti do GameOver ekrana

    void Start()
    {
        //podesavanja se ucitaju kao i skorovi
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
        //ako postoji igrac znaci da nije unisten i da nije kraj igre
        if (Igrac)
        {
            if (DozvoljenoKlizanje != 0)
            {
                if (DozvoljenoKlizanje > 0)
                    DozvoljenoKlizanje -= Time.deltaTime;
                else
                    DozvoljenoKlizanje = 0;
            }

            //ako je klizanje u toku onda se ne gleda ulaz, dok se ne zavrsi klizanje
            if (Klizanje != 0)
            {
                if (Klizanje > 0)
                    Klizanje -= Time.deltaTime;
                if (Klizanje < 0)
                    Klizanje = 0;
            }
            //inace se gledaju ulaznekomande:
            else
            {
                //ako tilt komande nisu ukljucene onda se proveravaju pritisci na ekran i/ili komande sa kontrolera
                if (!TiltKomande)
                {
                    //ako postoje pritisci na ekranu prolazi se kroz svaki pritisak i ako se nadju dva brza klika na istoj strani ekrana ukljucuje se klizanje
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
                    //ako nema pritisska na ekranu gleda se ulaz sa kontrolera(tastature,gamepada,joysticka...), po potrebi se aktivira klizanje
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
                //ako su aktivirane TILT komande onda:
                else
                {
                    skretanje = Input.acceleration.x * 5;//cita se orjentacija uredjaja i mnozi se sa 5(tako je ispalo da je najbolje, proveriti da ne postoji neka bolja konstanta za mnozenje)
                    if (Input.touchCount > 0)//ako se klikne(pritisne negde ekran) ukljucuje se klizanje
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
            //u svakom slucaju(sem mako je Igrac mrtav se skor povecava, kao i brzina kojom igrac ide
            Score += Brzina * Time.deltaTime * PoeniPoMetru;
                Brzina += (PovecanjeBrzinePoSekundi * Time.deltaTime);
        }
        //ako ne nadje igraca onda je game over
        else
        {
            VremeSmrti -= Time.deltaTime;
            if (VremeSmrti <= 0)
            {
                VremeSmrti = 3f;
                PrekiniIgru(2);//"GameOver screen" je u kompilovanju broj 2
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