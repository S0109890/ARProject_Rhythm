using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTH_RankManager : MonoBehaviour
{
    public static KTH_RankManager instance = null;
    private void Awake()
    {
        instance = this;
    }

    public GameObject[] Rank;

    void Start()
    {
        for (int i = 0; i < Rank.Length; i++)
        {
            Rank[i].SetActive(false);
        }

    }
}