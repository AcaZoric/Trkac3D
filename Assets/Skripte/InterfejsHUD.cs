using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterfejsHUD : MonoBehaviour
{
    public GameObject PauzaDugme;
    public GameObject PauzaMeni;
    public GameObject PodesavanjaMeni;

    public Slider SlajderZaBrzinu;
    public Slider SlajderZaPromenuBrzine;
    public Slider SlajderZaDupliKlik;
    public Slider SlajderZaBrzinuKliza;
    public Slider SlajderZaVremeKliza;

    private float brzina;
    private float povecanjeBrzine;
    private float dupliKlik;
    private float brzinaKliza;
    private float vremeKliza;

    void Start()
    {
        //na pocetku meniji su iskljuceni
        PodesavanjaMeni.SetActive(false);
        PauzaMeni.SetActive(false);
    }

    public void PauzirajIgru()
    {
        PauzaMeni.SetActive(true);
        PauzaDugme.SetActive(false);
        Time.timeScale = 0f;
    }
    public void PokreniIgru()
    {
        MenadzerIgre.menadzerIgre.UcitajPodesavanja();//ako su podesavanja promenjena opet se ucitavaju, ako nisu opet ce ista da se ucitaju tako da nema problema
        PauzaMeni.SetActive(false);
        PauzaDugme.SetActive(true);
        Time.timeScale = 1;
    }

    //kada se pritisne dugme PODESAVANJA u meniju, poziva se ova funkcija koja sluzi za inicijalizaciju vrednosti interfejsa u meniju za podesavanja
    public void Podesavanja()
    {
        PodesavanjaMeni.SetActive(!PodesavanjaMeni.activeSelf);

        SlajderZaBrzinu.value = MenadzerIgre.menadzerIgre.Brzina;
        SlajderZaPromenuBrzine.value = PodesavanjaCuvanje.podesavanja.PovecanjeBrzinePoSekundi;
        SlajderZaDupliKlik.value = PodesavanjaCuvanje.podesavanja.VremeZaKlizanje;
        SlajderZaBrzinuKliza.value = PodesavanjaCuvanje.podesavanja.BrzinaKlizanja;
        SlajderZaVremeKliza.value = PodesavanjaCuvanje.podesavanja.VremeKlizanja;
    }

    //poziva se kada se pritisne dugme PRIMENI u podesavanjima
    public void PrimeniPodesavanja()
    {
        MenadzerIgre.menadzerIgre.Brzina = brzina;
        PodesavanjaCuvanje.podesavanja.PovecanjeBrzinePoSekundi = povecanjeBrzine;
        PodesavanjaCuvanje.podesavanja.VremeZaKlizanje = dupliKlik;
        PodesavanjaCuvanje.podesavanja.BrzinaKlizanja = brzinaKliza;
        PodesavanjaCuvanje.podesavanja.VremeKlizanja = vremeKliza;
        PodesavanjaCuvanje.podesavanja.Sacuvaj();
    }

    //ZA SLAJDERE, da probamo
    public void SlajderBrzina(float ZeljenaBrzina)
    {
        brzina = ZeljenaBrzina;
    }

    public void SlajderPovecanjeBrzine(float ZeljenoPovecanje)
    {
        povecanjeBrzine = ZeljenoPovecanje;
    }

    public void SlajderDupliKlik(float DupliKlik)
    {
        dupliKlik = DupliKlik;
    }

    public void SlajderBrzinaKlizanja(float ZeljenaBrzinaKlizanja)
    {
        brzinaKliza = ZeljenaBrzinaKlizanja;
    }

    public void SlajderVremeKlizanja(float ZeljenoVremeKlizanja)
    {
        vremeKliza = ZeljenoVremeKlizanja;
    }
}
