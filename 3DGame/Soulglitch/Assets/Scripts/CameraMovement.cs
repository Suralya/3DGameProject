using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{

    private float _speedfactor = 25f;
    public float StartSpeed = 25f;
    public int Borderwidth = 20;
	public float Boost=2f;

    // Use this for initialization
    void Start()
    {

    }

	//KAMERABEGRENZUNG SCHREIBEN!!!!!!!!!!!!


    // Update is called once per frame
    void Update()
    {

        //Cameramovement via WASD
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
            MoveUp();

		if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
            MoveDown();

		if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
            MoveRight();

		if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
            MoveLeft();

        if (!Input.anyKey)
        {
            //Cameramovement via Mouse

            if (Input.mousePosition.x > Screen.width - Borderwidth)
            {
                MoveLeft(); _speedfactor += Boost;
            }
            else if (Input.mousePosition.x < 0 + Borderwidth)
            {
				MoveRight(); _speedfactor += Boost;
            }
            else if (Input.mousePosition.y > Screen.height - Borderwidth)
            {
				MoveUp(); _speedfactor += Boost;
            }
            else if (Input.mousePosition.y < 0 + Borderwidth)
            {
				MoveDown(); _speedfactor += Boost;
            }
            else
            {
                _speedfactor = StartSpeed;
            }
        }
		else { _speedfactor += Boost; }




    }

    private void MoveUp()
    {
      /*  Vector3 temp = this.transform.position;
        temp.z += 1 * _speedfactor;

        this.transform.position = temp;*/

		this.transform.Translate (Vector3.forward * Time.deltaTime*_speedfactor);
    }
    private void MoveDown()
    {
  /*      Vector3 temp = this.transform.position;
        temp.z -= 1 * _speedfactor;

        this.transform.position = temp;
        */

		this.transform.Translate (Vector3.back * Time.deltaTime*_speedfactor);
    }
    private void MoveRight()
    {
      /*  Vector3 temp = this.transform.position;
        temp.x -= 1 * _speedfactor;

        this.transform.position = temp;

	*/
		this.transform.Translate (Vector3.left * Time.deltaTime*_speedfactor);
    }
    private void MoveLeft()
    {
      /*  Vector3 temp = this.transform.position;
        temp.x += 1 * _speedfactor;

        this.transform.position = temp;
        */
		this.transform.Translate (Vector3.right * Time.deltaTime*_speedfactor);
    }
}
