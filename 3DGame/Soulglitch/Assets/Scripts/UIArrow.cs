using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIArrow : MonoBehaviour
{

    public Sprite Avain;
    public Sprite Avaout;
    public Image Img;

	// Use this for initialization
	void Start ()
	{
	    Img.sprite = Avain;
	}

    // Update is called once per frame
	void Update () {
        
	
	}

    public void ChangeAva()
    {
        Img.sprite = Img.sprite==Avain ? Avaout : Avain;
    }
}
