using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PodesavanjaCuvanje : MonoBehaviour
{
    public static PodesavanjaCuvanje podesavanja;

    public bool TiltKomande = false;
    public bool TiltVirtualni = false;
    public int PoeniPoMetru = 1;
    public float PocetnaBrzina = 20f;
    public float PovecanjeBrzinePoSekundi = 1f;
    public float BrzinaKlizanja = 5f;
    public float VremeKlizanja = 0.1f;//trajanje klizanja
    public float VremeZaKlizanje = 0.1f;//vreme za koje vredi dupli klik
    public float VremeSmrti = 1.5f;

    void Awake()
    {
        if (!podesavanja)
        {
            DontDestroyOnLoad(gameObject);
            podesavanja = this;
            Ucitaj();
        }
        else if (podesavanja != this)
        {
            Destroy(gameObject);
        }
    }

    public void Sacuvaj()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fajl = File.Create(Application.persistentDataPath + "/Podesavanja.dat");

        PodesavanjaPodaci podaci = new PodesavanjaPodaci();
        podaci.TiltKomande = TiltKomande;
        podaci.PoeniPoMetru = PoeniPoMetru;
        podaci.PocetnaBrzina = PocetnaBrzina;
        podaci.PovecanjeBrzinePoSekundi = PovecanjeBrzinePoSekundi;
        podaci.BrzinaKlizanja = BrzinaKlizanja;
        podaci.VremeKlizanja = VremeKlizanja;
        podaci.VremeZaKlizanje = VremeZaKlizanje;
        podaci.VremeSmrti = VremeSmrti;

        bf.Serialize(fajl, podaci);
        fajl.Close();
    }

    public void Ucitaj()
    {
        if (!File.Exists(Application.persistentDataPath + "/Podesavanja.dat"))
        {
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fajl = File.Open(Application.persistentDataPath + "/Podesavanja.dat",FileMode.Open);
        PodesavanjaPodaci podaci = (PodesavanjaPodaci)bf.Deserialize(fajl);
        fajl.Close();

        TiltKomande = podaci.TiltKomande;
        PoeniPoMetru = podaci.PoeniPoMetru;
        PocetnaBrzina = podaci.PocetnaBrzina;
        PovecanjeBrzinePoSekundi = podaci.PovecanjeBrzinePoSekundi;
        BrzinaKlizanja = podaci.BrzinaKlizanja;
        VremeKlizanja = podaci.VremeKlizanja;
        VremeZaKlizanje = podaci.VremeZaKlizanje;
        VremeSmrti = podaci.VremeSmrti;
    }
}

[Serializable]
class PodesavanjaPodaci
{
    public bool TiltKomande;
    public int PoeniPoMetru;
    public float PocetnaBrzina;
    public float PovecanjeBrzinePoSekundi;
    public float BrzinaKlizanja;
    public float VremeKlizanja;
    public float VremeZaKlizanje;
    public float VremeSmrti;
}
