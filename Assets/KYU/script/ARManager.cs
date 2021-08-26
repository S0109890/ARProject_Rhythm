using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARManager : MonoBehaviour
{
    public GameObject indicator;
    public GameObject start;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStart();
        UpdateIndicator();
    }

    private void UpdateIndicator()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.position);
        RaycastHit hitinfo;
        if(Physics.Raycast(ray, out hitinfo))
        {
            indicator.SetActive(true);
            indicator.transform.position = hitinfo.point;
        }
        else
        {
            indicator.SetActive(false);
        }
    }

    private void UpdateStart()
    {
        throw new NotImplementedException();
    }
}
