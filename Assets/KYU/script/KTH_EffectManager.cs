using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTH_EffectManager : MonoBehaviour
{
    //싱글톤
    public static KTH_EffectManager instance = null;

    private void Awake()
    {
        instance = this;

    }
    //싱글톤
   

    //판정텍스트 애니메이터 붙여준다.
    //[SerializeField] Animator perfectAnimator = null;
    //string perfect = "Perfect";
    //[SerializeField] Animator goodAnimator = null;
    //string good = "Good";
    //[SerializeField] Animator okAnimator = null;
    //string ok = "Ok";
    //[SerializeField] Animator missAnimator = null;
    //string miss = "Miss";
    [SerializeField] GameObject per;
    [SerializeField] GameObject great;
    [SerializeField] GameObject good;
    [SerializeField] GameObject miss;





    //판정 이펙트 함수. 애니메이션 플레이
    public void PerfectHitEffect()
    {
        //perfectAnimator.SetTrigger(perfect);
        StartCoroutine(Per());
       
    }

    public void GoodHitEffect()
    {
        StartCoroutine(Great());

        //goodAnimator.SetTrigger(good);
    }

    public void OkHitEffect()
    {
        StartCoroutine(Good());

        //okAnimator.SetTrigger(ok);
    }

    public void MissHitEffect()
    {
        StartCoroutine(Miss());

        //missAnimator.SetTrigger(miss);
    }



    IEnumerator Per()
    {
        per.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        per.SetActive(false);

    }
    IEnumerator Great()
    {
        great.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        great.SetActive(false);

    }
    IEnumerator Good()
    {
        good.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        good.SetActive(false);

    }
    IEnumerator Miss()
    {
        miss.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        miss.SetActive(false);

    }
}
