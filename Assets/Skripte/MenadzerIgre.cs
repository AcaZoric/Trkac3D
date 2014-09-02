using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenadzerIgre : MonoBehaviour
{
	public Text NajSkorLabela;
	public Text SkorLabela;
	public Text KrajLabela;
	public GameObject PauzaDugme;
	public GameObject PauzaMeni;
	public GameObject PodesavanjaMeni;

	public static MenadzerIgre menadzerIgre;
	public float skretanje = 0f;
	public GameObject Igrac;
	public int PoeniPoMetru = 1;
	public float PocetnaBrzina = 20f;
	public float Brzina = 20f;
	public float PovecanjeBrzinePoSekundi = 1f;
	public float BrzinaKlizanja = 5f;
	public float VremeKlizanja = 0.2f;//trajanje klizanja
	public float VremeZaKlizanje = 0.2f;//vreme za koje vredi dupli klik

	private float Score = 0f;
	private static float HighScore = 0f;
	private float VremeSmrti = 1.5f;
	private float Klizanje = 0f;
	private float strana = 0f;
	private float DozvoljenoKlizanje= 0f;

	private float pomocna;
	void Start ()
	{
		PodesavanjaMeni.SetActive(false);
		PauzaMeni.SetActive (false);
		Brzina = PocetnaBrzina;
		HighScore = PlayerPrefs.GetFloat ("HighScore");
		menadzerIgre = this;
		NajSkorLabela.text="Najbolji rezultat: " + (int)HighScore;
	}

	void Update ()
	{
		SkorLabela.text = "Rezultat: " + (int)Score;
		if (Igrac) 
		{
			if(DozvoljenoKlizanje!=0)
			{
				if(DozvoljenoKlizanje>0)
					DozvoljenoKlizanje-=Time.deltaTime;
				else
					DozvoljenoKlizanje=0;
			}

			if (Klizanje != 0)
			{
				if(Klizanje>0)
					Klizanje -= Time.deltaTime;
				if(Klizanje<0)
					Klizanje = 0;
			}
			else 
			{
				if (Input.touchCount > 0) 
				{
					foreach (Touch touch in Input.touches) 
					{
						if (touch.position.x < Screen.width / 2) 
						{
							if(skretanje==0 && strana == -1 && DozvoljenoKlizanje!=0)
							{
								skretanje=-1*BrzinaKlizanja;
								Klizanje=VremeKlizanja;
							}
							else
							{
								skretanje = -1;
								DozvoljenoKlizanje=VremeZaKlizanje;
								strana=-1;
							}
						} 
						else 
						{
							if(skretanje==0 && strana == 1 && DozvoljenoKlizanje!=0)
							{
								skretanje = BrzinaKlizanja;
								Klizanje=VremeKlizanja;
							}
							else
							{
								skretanje = 1;
								DozvoljenoKlizanje=VremeZaKlizanje;
								strana=1;
							}
						}
					}
				} 
				else
				{
					if (skretanje == 0 && (skretanje = Input.GetAxis ("Horizontal")) != 0 && skretanje == strana && DozvoljenoKlizanje != 0) 
					{
						skretanje *= BrzinaKlizanja;
						Klizanje=VremeKlizanja;
					} 
					else 
					{
						if ((skretanje = Input.GetAxis ("Horizontal")) != 0) 
						{
							DozvoljenoKlizanje=VremeZaKlizanje;
							strana = skretanje;
						}
					}
				}
			}
			Score += Brzina * Time.deltaTime * PoeniPoMetru;
			if(Brzina!=0)
				Brzina = Brzina + (PovecanjeBrzinePoSekundi * Time.deltaTime);
		}
		//ako ne nadje igraca onda je game over
		else 
		{
			VremeSmrti -= Time.deltaTime;
			KrajLabela.text="Kraj Igre!";
			PauzaDugme.SetActive (false);
			if (VremeSmrti <= 0) 
			{
				VremeSmrti = 3f;
				PrekiniIgru(2);
			}
		}
	}
	public void PrekiniIgru(int VratiNa)
	{
		Time.timeScale=1;
		PlayerPrefs.SetFloat ("Score", Score);
		if (Score > HighScore) 
		{
			HighScore = Score;
			PlayerPrefs.SetFloat ("HighScore", HighScore);
		}
		Application.LoadLevel (VratiNa);
	}
	public void PauzirajIgru()
	{
		PauzaMeni.SetActive (true);
		PauzaDugme.SetActive (false);
		Time.timeScale=0f;
	}
	public void PokreniIgru()
	{
		PauzaMeni.SetActive (false);
		PauzaDugme.SetActive (true);
		Time.timeScale=1;
	}
	
	public void Podesavanja()
	{
		PodesavanjaMeni.SetActive (!PodesavanjaMeni.activeSelf);
	}
	//ZA SLAJDERE, da probamo
	public void SlajderBrzina(float ZeljenaBrzina)
	{
		Brzina=ZeljenaBrzina;
	}
	public void SlajderPovecanjeBrzine(float ZeljenoPovecanje)
	{
		PovecanjeBrzinePoSekundi=ZeljenoPovecanje;
	}
	public void SlajderDupliKlik(float DupliKlik)
	{
		VremeZaKlizanje=DupliKlik;
	}
	public void SlajderBrzinaKlizanja(float ZeljenaBrzinaKlizanja)
	{
		BrzinaKlizanja=ZeljenaBrzinaKlizanja;
	}
	public void SlajderVremeKlizanja(float ZeljenoVremeKlizanja)
	{
		VremeKlizanja=ZeljenoVremeKlizanja;
	}
}
