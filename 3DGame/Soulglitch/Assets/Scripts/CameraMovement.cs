using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{

    private float _speedfactor = 0.5f;
    public float StartSpeed = 0.1f;
    public int Borderwidth = 20;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Cameramovement via WASD
        if (Input.GetKey(KeyCode.W))
            MoveUp();

        if (Input.GetKey(KeyCode.S))
            MoveDown();

        if (Input.GetKey(KeyCode.A))
            MoveRight();

        if (Input.GetKey(KeyCode.D))
            MoveLeft();

        if (!Input.anyKey)
        {
            //Cameramovement via Mouse

            if (Input.mousePosition.x > Screen.width - Borderwidth)
            {
                MoveLeft(); _speedfactor += 0.04f;
            }
            else if (Input.mousePosition.x < 0 + Borderwidth)
            {
                MoveRight(); _speedfactor += 0.04f;
            }
            else if (Input.mousePosition.y > Screen.height - Borderwidth)
            {
                MoveUp(); _speedfactor += 0.04f;
            }
            else if (Input.mousePosition.y < 0 + Borderwidth)
            {
                MoveDown(); _speedfactor += 0.04f;
            }
            else
            {
                _speedfactor = StartSpeed;
            }
        }
        else { _speedfactor += 0.04f; }




    }

    private void MoveUp()
    {
        Vector3 temp = this.transform.position;
        temp.z += 1 * _speedfactor;

        this.transform.position = temp;
    }
    private void MoveDown()
    {
        Vector3 temp = this.transform.position;
        temp.z -= 1 * _speedfactor;

        this.transform.position = temp;
    }
    private void MoveRight()
    {
        Vector3 temp = this.transform.position;
        temp.x -= 1 * _speedfactor;

        this.transform.position = temp;
    }
    private void MoveLeft()
    {
        Vector3 temp = this.transform.position;
        temp.x += 1 * _speedfactor;

        this.transform.position = temp;
    }
}
