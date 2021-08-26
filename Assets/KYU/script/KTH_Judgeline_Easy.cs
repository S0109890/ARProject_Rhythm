using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTH_Judgeline_Easy : MonoBehaviour
{
    public GameObject Linenum;


    void Update()
    {
        //만약 Linenum에 터치가 됐다면.
        if (Input.GetTouch(0).phase == TouchPhase.Began && Linenum)
        {
            int layer = 1 << LayerMask.NameToLayer("Note");
            Collider[] cols = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, layer);

            if (cols == null || cols.Length == 0)
            {
                print("Miss");
                //KTH_ComboManager.instance.ResetCombo();
                //KTH_EffectManager.instance.MissHitEffect();
                //KTH_RecordManager.instance.MissRecord();
            }

            for (int i = 0; i < cols.Length; i++)
            {
                float dist = Mathf.Abs(transform.position.x - 
                    cols[i].gameObject.transform.position.x);
                Destroy(cols[i].gameObject);

                if (dist > 0 && dist < 1.0f)
                {
                    print("Perfect");
                    //KTH_ScoreManager.instance.IncreaseScore(0);
                    //KTH_EffectManager.instance.PerfectHitEffect();
                    //KTH_RecordManager.instance.PerfectRecord();
                }

                else if (dist > 1.0f && dist < 1.5f)
                {
                    print("Good");
                    //KTH_ScoreManager.instance.IncreaseScore(1);
                    //KTH_EffectManager.instance.GoodHitEffect();
                    //KTH_RecordManager.instance.GoodRecord();
                }

                else if (dist > 1.5f && dist < 2.0f)
                {
                    print("OK");
                    //KTH_ScoreManager.instance.IncreaseScore(2);
                    //KTH_EffectManager.instance.OkHitEffect();
                    //KTH_RecordManager.instance.OkRecord();
                    
                }
            }
        }
    }
    
}
