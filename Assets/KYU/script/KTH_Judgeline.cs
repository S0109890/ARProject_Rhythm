using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTH_Judgeline : MonoBehaviour
{
    KTH_EffectManager missEffect;
    void Start()
    {
        missEffect = FindObjectOfType<KTH_EffectManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Note(Clone)" || other.gameObject.name == "N3NOTE(Clone)")
        {
            KTH_ComboManager.instance.ResetCombo();
            missEffect.MissHitEffect();
            KTH_RecordManager.instance.MissRecord();
        }
    }
}
