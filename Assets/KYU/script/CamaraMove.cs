using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    public GameObject[] CameraPosition;

    public GameObject CameraRot;
    public float thetime = 120;
    public float secthetime;
    bool onetime = false;
    bool twotime = false;
    bool threetime = false;

    private void Start()
    {

    }
    void Update()
    {

        if (thetime > 0)
        {
            thetime -= Time.deltaTime;
            if (thetime <= 97 && thetime >= 96)
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, CameraPosition[0].transform.position, 0.05f);
                print("실행중0");
            }
            if (thetime <= 96.6f && !onetime && thetime >= 95.6f)
            {
                transform.Rotate(Vector3.right * 30);
                onetime = true;
                print("실행중a");
            }
            if (thetime <= 85 && thetime >= 84)
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, CameraPosition[1].transform.position, 0.05f);
                onetime = false;
                print("실행중b");
            }
            if (thetime <= 84.6f && !twotime && thetime >= 83.6f)
            {
                transform.Rotate(Vector3.left * 30);
                twotime = true;
                print("실행중c");
            }
            if (thetime <= 42 && thetime >= 39)
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, CameraPosition[2].transform.position, 0.03f);
                onetime = false;
                print("실행중d");
            }

            if (thetime <= 42 && !threetime && thetime >= 39)
            {
                transform.Rotate(Vector3.right * 40);
                threetime = true;
                print("실행중f");

            }
            //transform.position = Vector3.MoveTowards(gameObject.transform.position, CameraPosition.transform.position, 0.05f);

        }
    }
}

