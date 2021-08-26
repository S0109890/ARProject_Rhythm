using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTH_Judgeline_Hard : MonoBehaviour
{
    public KeyCode keycode;
    bool isJudge;
    bool isProcess;
    int[] judgementRecord = new int[4];

    void Start()
    {
        isJudge = false;
        isProcess = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            int layer = 1 << LayerMask.NameToLayer("Note3");
            Collider[] cols = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, layer);

            if (cols == null || cols.Length == 0)
            {
                KTH_ComboManager.instance.ResetCombo();
                KTH_EffectManager.instance.MissHitEffect();
                KTH_RecordManager.instance.MissRecord();
            }

            for (int i = 0; i < cols.Length; i++)
            {
                float dist = Mathf.Abs(transform.position.y -
                    cols[i].gameObject.transform.position.y);
                Destroy(cols[i].gameObject);

                if (dist > 0 && dist < 1.4f)
                {
                    KTH_ScoreManager.instance.IncreaseScore(0);
                    KTH_EffectManager.instance.PerfectHitEffect();
                    KTH_RecordManager.instance.PerfectRecord();
                }

                else if (dist > 1.4f && dist < 1.7f)
                {
                    KTH_ScoreManager.instance.IncreaseScore(1);
                    KTH_EffectManager.instance.GoodHitEffect();
                    KTH_RecordManager.instance.GoodRecord();
                }

                else if (dist > 1.7f && dist < 2.0f)
                {
                    KTH_ScoreManager.instance.IncreaseScore(2);
                    KTH_EffectManager.instance.OkHitEffect();
                    KTH_RecordManager.instance.OkRecord();
                }
            }

            int layer2 = 1 << LayerMask.NameToLayer("NoteS");
            Collider[] cols2 = Physics.OverlapBox(transform.position,
                transform.localScale / 2, Quaternion.identity, layer2);

            if (cols2 == null || cols2.Length == 0)
            {
                KTH_ComboManager.instance.ResetCombo();
                KTH_EffectManager.instance.MissHitEffect();
                KTH_RecordManager.instance.MissRecord();
            }

            for (int i = 0; i < cols2.Length; i++)
            {
                isJudge = true;
            }
        }

        else if (isJudge && Input.GetKey(keycode))
        {
            isProcess = true;
        }

        else if (isJudge && isProcess && Input.GetKeyUp(keycode))
        {
            isJudge = false;
            isProcess = false;
            int layer3 = 1 << LayerMask.NameToLayer("NoteF");
            Collider[] cols3 = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, layer3);

            for (int j = 0; j < cols3.Length; j++)
            {
                KTH_ScoreManager.instance.IncreaseScore(0);
                KTH_EffectManager.instance.PerfectHitEffect();
                KTH_RecordManager.instance.PerfectRecord();
            }
        }
    }
}