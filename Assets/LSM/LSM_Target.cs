using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//타겟을 가진다.
//타겟까지 그림을 그린다.
public class LSM_Target : MonoBehaviour
{
    public GameObject target;

    LineRenderer lr;
    // Start is called before the first frame update
    public void CreateLine(Vector3 targetPos)
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, targetPos);
        //print(target.transform.position * -1f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
