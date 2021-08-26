using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//타겟을 가지고있고싶다.

public class LSM_TargeManager : MonoBehaviour
{
    public LaManager laManager;
    public LSM_SetStartPosition[] targets;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetDir = LSM_ARManager.instance.indicator.transform.position - Camera.main.transform.position;
        targetDir.Normalize();




        laManager.spawns = new GameObject[targets.Length];
        laManager.targets = new GameObject[targets.Length];
        //float distance = Vector3.Distance(LSM_ARManager.instance.indicator.transform.position, Camera.main.transform.position);
        float distance = 12;
#if UNITY_EDITOR
    distance = 12;
#endif
        for (int i = 0; i < targets.Length; i++)
        {

            targets[i].CreateStart(distance);
            targets[i].start.GetComponent<LSM_Target>().CreateLine(targets[i].transform.position);
            
            laManager.spawns[i] = targets[i].start;
            laManager.targets[i] = targets[i].gameObject;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
