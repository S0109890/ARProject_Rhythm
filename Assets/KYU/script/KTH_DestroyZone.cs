using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 나에게 감지된 게임오브젝트를 파괴하고싶다.
public class KTH_DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}