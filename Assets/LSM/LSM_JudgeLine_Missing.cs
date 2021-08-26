using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSM_JudgeLine_Missing : MonoBehaviour
{
    //판정이펙트함수를 가져온다
    KTH_EffectManager missEffect;
    void Start()
    {
        missEffect = FindObjectOfType<KTH_EffectManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //만약 충돌한 물체가 노트 이름을 가지고 있다면
        if (other.gameObject.name.Contains("Note"))
        {
            //프린트로 확인하고
            print("안눌러서miss");
            //콤보매니져에서 콤보 리셋
            KTH_ComboManager.instance.ResetCombo();
            //미스이펙트 띄우기
            missEffect.MissHitEffect();
            //기록매니져에서.미스기록하기
            KTH_RecordManager.instance.MissRecord();
        }
    }
}
