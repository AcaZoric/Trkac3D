using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlavniMeniMenadzer : MonoBehaviour
{
    public GameObject podesavanjaPanel;

    public Toggle TiltKomandeToggle;
    public Toggle TiltVirtualniToggle;
    public Slider PoeniPoMetruSlider;
    public Slider PocetnaBrzinaSlider;
    public Slider PovecanjeBrzinePoSekundiSlider;
    public Slider BrzinaKlizanjaSlider;
    public Slider VremeKlizanjaSlider;
    public Slider VremeZaKlizanjeSlider;
    public Slider VremeSmrtiSlider;

    public void UcitajNivo(int Nivo)
    {
        Application.LoadLevel(Nivo);
    }

    public void UcitajPodesavanja()
    {
        podesavanjaPanel.SetActive(!podesavanjaPanel.activeSelf);

        TiltKomandeToggle.isOn = PodesavanjaCuvanje.podesavanja.TiltKomande;
        TiltVirtualniToggle.isOn = PodesavanjaCuvanje.podesavanja.TiltVirtualni;
        PoeniPoMetruSlider.value = PodesavanjaCuvanje.podesavanja.PoeniPoMetru;
        PocetnaBrzinaSlider.value = PodesavanjaCuvanje.podesavanja.PocetnaBrzina;
        PovecanjeBrzinePoSekundiSlider.value = PodesavanjaCuvanje.podesavanja.PovecanjeBrzinePoSekundi;
        BrzinaKlizanjaSlider.value = PodesavanjaCuvanje.podesavanja.BrzinaKlizanja;
        VremeKlizanjaSlider.value = PodesavanjaCuvanje.podesavanja.VremeKlizanja;
        VremeZaKlizanjeSlider.value = PodesavanjaCuvanje.podesavanja.VremeZaKlizanje;
        VremeSmrtiSlider.value = PodesavanjaCuvanje.podesavanja.VremeSmrti;
    }

    public void PrimeniPodesavanja()
    {
        PodesavanjaCuvanje.podesavanja.TiltKomande = TiltKomandeToggle.isOn;
        PodesavanjaCuvanje.podesavanja.TiltVirtualni = TiltVirtualniToggle.isOn;
        PodesavanjaCuvanje.podesavanja.PoeniPoMetru = (int)PoeniPoMetruSlider.value;
        PodesavanjaCuvanje.podesavanja.PocetnaBrzina = PocetnaBrzinaSlider.value;
        PodesavanjaCuvanje.podesavanja.PovecanjeBrzinePoSekundi = PovecanjeBrzinePoSekundiSlider.value;
        PodesavanjaCuvanje.podesavanja.VremeZaKlizanje = VremeSmrtiSlider.value;
        PodesavanjaCuvanje.podesavanja.BrzinaKlizanja = BrzinaKlizanjaSlider.value;
        PodesavanjaCuvanje.podesavanja.VremeKlizanja = VremeKlizanjaSlider.value;
        PodesavanjaCuvanje.podesavanja.VremeSmrti = VremeKlizanjaSlider.value;
    }
    public void IzadjiIzIgre()
    {
        Application.Quit();
    }
}
