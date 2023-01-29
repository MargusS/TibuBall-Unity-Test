using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam3rd;
    public GameObject camDiametric;

    private void Start()
    {
        cam3rd.SetActive(true);
        camDiametric.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam3rd.SetActive(!cam3rd.activeSelf);
            camDiametric.SetActive(!camDiametric.activeSelf);
        }
    }
}
