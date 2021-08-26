using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//판정영역을 클릭하면 노트를 인식하고싶다.
public class LSM_Judgeline_Easy : MonoBehaviour
{
    //public Text comboText;
    MeshRenderer mr;
    LSM_LerpNote note;
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
    }

    IEnumerator IEColor()
    { 
        mr.material.color = Color.green;
        yield return new WaitForSeconds(0.3f);
        mr.material.color = Color.white;


    }
    private void OnTriggerExit(Collider other)
    {
        note.col.enabled = false;
    }
    private void OnMouseDown()
    {
        StartCoroutine(IEColor());

        //레이어를 만들어서 : 노트만인지하고싶다
        int layer = 1 << LayerMask.NameToLayer("Note");
        //물체에 충동박스를 만들어서 닿은것을 인지하고싶다.
        Collider[] cols = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, layer);

        //miss처리
        if (cols == null || cols.Length == 0)
        {
            print("Miss");
            KTH_ComboManager.instance.ResetCombo();
            KTH_EffectManager.instance.MissHitEffect();
            //KTH_RecordManager.instance.MissRecord();
        }


        //나머지는 맞은거

        for (int i = 0; i < cols.Length; i++)
        {
            float dist = Mathf.Abs(transform.position.x -
                cols[i].gameObject.transform.position.x);
            Destroy(cols[i].gameObject);

            //퍼펙트처리
            if (dist > 0 && dist < 1.0f)
            {
                print("Perfect");
                KTH_ScoreManager.instance.IncreaseScore(0);
                KTH_EffectManager.instance.PerfectHitEffect();
                //KTH_RecordManager.instance.PerfectRecord();
            }

            //굿 처리
            else if (dist > 1.0f && dist < 1.5f)
            {
                print("Good");
                KTH_ScoreManager.instance.IncreaseScore(1);
                KTH_EffectManager.instance.GoodHitEffect();
                //KTH_RecordManager.instance.GoodRecord();
            }


            //오케이처리
            else if (dist > 1.5f && dist < 2.0f)
            {
                print("OK");
                KTH_ScoreManager.instance.IncreaseScore(2);
                KTH_EffectManager.instance.OkHitEffect();
                //KTH_RecordManager.instance.OkRecord();

            }

        }
        
    }
}



















//        if (Input.GetMouseButtonDown(0))
//        {
//            //카메라에서 레이의 시작점을 만들어서 월드에 쏘고싶다
//            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//            //테스트로 그려보고싶다
//            Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
//            //
//            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
//            {
//                //뭔가에 닿았다면 출력해보고싶다
//                Debug.Log("뭔가에 닿았다");
//                hitInfo.point = point.transform.position;
//                //레이어를 만들어서 : 노트만인지하고싶다
//                int layer = 1 << LayerMask.NameToLayer("Note");
//                Collider[] cols = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, layer);

//                if (cols == null || cols.Length == 0)
//                {
//                    print("Miss");
//                    //KTH_ComboManager.instance.ResetCombo();
//                    //KTH_EffectManager.instance.MissHitEffect();
//                    //KTH_RecordManager.instance.MissRecord();
//                }

//                for (int i = 0; i < cols.Length; i++)
//                {
//                    float dist = Mathf.Abs(transform.position.x -
//                        cols[i].gameObject.transform.position.x);
//                    Destroy(cols[i].gameObject);

//                    if (dist > 0 && dist < 1.0f)
//                    {
//                        print("Perfect");
//                        //KTH_ScoreManager.instance.IncreaseScore(0);
//                        //KTH_EffectManager.instance.PerfectHitEffect();
//                        //KTH_RecordManager.instance.PerfectRecord();
//                    }

//                    else if (dist > 1.0f && dist < 1.5f)
//                    {
//                        print("Good");
//                        //KTH_ScoreManager.instance.IncreaseScore(1);
//                        //KTH_EffectManager.instance.GoodHitEffect();
//                        //KTH_RecordManager.instance.GoodRecord();
//                    }

//                    else if (dist > 1.5f && dist < 2.0f)
//                    {
//                        print("OK");
//                        //KTH_ScoreManager.instance.IncreaseScore(2);
//                        //KTH_EffectManager.instance.OkHitEffect();
//                        //KTH_RecordManager.instance.OkRecord();

//                    }

//                }
//            }
//        }
//    }
//}
        

    //    if (/*Input.GetTouch(0).phase == TouchPhase.Began ||*/)
    //    {
    //        int layer = 1 << LayerMask.NameToLayer("Note");
    //        Collider[] cols = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, layer);

    //        if (cols == null || cols.Length == 0)
    //        {
    //            print("Miss");
    //            //KTH_ComboManager.instance.ResetCombo();
    //            //KTH_EffectManager.instance.MissHitEffect();
    //            //KTH_RecordManager.instance.MissRecord();
    //        }

    //        for (int i = 0; i < cols.Length; i++)
    //        {
    //            float dist = Mathf.Abs(transform.position.x - 
    //                cols[i].gameObject.transform.position.x);
    //            Destroy(cols[i].gameObject);

    //            if (dist > 0 && dist < 1.0f)
    //            {
    //                print("Perfect");
    //                //KTH_ScoreManager.instance.IncreaseScore(0);
    //                //KTH_EffectManager.instance.PerfectHitEffect();
    //                //KTH_RecordManager.instance.PerfectRecord();
    //            }

    //            else if (dist > 1.0f && dist < 1.5f)
    //            {
    //                print("Good");
    //                //KTH_ScoreManager.instance.IncreaseScore(1);
    //                //KTH_EffectManager.instance.GoodHitEffect();
    //                //KTH_RecordManager.instance.GoodRecord();
    //            }

    //            else if (dist > 1.5f && dist < 2.0f)
    //            {
    //                print("OK");
    //                //KTH_ScoreManager.instance.IncreaseScore(2);
    //                //KTH_EffectManager.instance.OkHitEffect();
    //                //KTH_RecordManager.instance.OkRecord();
                    
    //            }
    //        }
    //    }
    //}
    

