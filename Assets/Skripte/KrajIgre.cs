using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KrajIgre : MonoBehaviour
{
    public GameObject Skor;
    public GameObject NajSkor;

	void Start ()
    {
        Skor.GetComponent<Text>().text = "Vas rezultat je: " + ((int)PlayerPrefs.GetFloat("Score")).ToString();
        NajSkor.GetComponent<Text>().text = "Najbolji rezultat je: " + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
	}
}
