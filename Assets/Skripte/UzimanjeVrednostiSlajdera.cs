using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UzimanjeVrednostiSlajdera : MonoBehaviour
{
    public Slider Slajder;
	private Text vrednost;

	void Start()
	{
		vrednost=this.gameObject.GetComponent<Text>();
	}

	void Update ()
	{
		vrednost.text= System.Math.Round(Slajder.value,1).ToString();
	}
}
