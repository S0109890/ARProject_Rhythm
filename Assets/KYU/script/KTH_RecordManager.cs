using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTH_RecordManager : MonoBehaviour
{
    //싱글톤
    public static KTH_RecordManager instance;


    private void Awake()
    {
        instance = this;
    }
    //싱글톤


    public int[] judgementRecord = new int[4];



    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }
    public void PerfectRecord()
    {
        judgementRecord[0]++;
    }
    public void GoodRecord()
    {
        judgementRecord[1]++;
    }
    public void OkRecord()
    {
        judgementRecord[2]++;
    }
    public void MissRecord()
    {
        judgementRecord[3]++;
    }
}
