using UnityEngine;
using System.Collections;

public class DisableUI : MonoBehaviour
{

    public Canvas Interfacebuttons, Tooltip, Questlog;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance._userturn)
        {
            Interfacebuttons.enabled = false;
            Tooltip.enabled = false;
            Questlog.enabled = false;

        }
        else
        {
            Interfacebuttons.enabled = true;
            if (GameManager.instance.Tooltipshown)
                Tooltip.enabled = true;
            if (GameManager.instance.Questlogshown)
                Questlog.enabled = true;

        }

    }
}
