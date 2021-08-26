using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KTH_Result : MonoBehaviour
{
    //싱글톤
    public static KTH_Result instance = null;

    private void Awake()
    {
        instance = this;
    }
    //싱글톤

    [SerializeField] GameObject goUI = null;
    [SerializeField] Text[] Count = null;
    [SerializeField] Text Scoretext = null;
    [SerializeField] Text Maxcombotext = null;

    // Start is called before the first frame update
    void Start()
    {
        goUI.SetActive(false);
    }

    public void ShowResult()
    {
        goUI.SetActive(true);

        for (int i = 0; i < Count.Length; i++)
            Count[i].text = "0";
        Scoretext.text = "0";
        Maxcombotext.text = "0";

        int[] t_judgement = KTH_RecordManager.instance.GetJudgementRecord();
        int t_currentScore = KTH_ScoreManager.instance.GetCurrentScore();
        int t_maxCombo = KTH_ComboManager.instance.GetMaxCombo();

        for (int i = 0; i < Count.Length; i++)
        {
            Count[i].text = string.Format("{0:#,##0}", t_judgement[i]);
        }

        Scoretext.text = string.Format("{0:#,##0}", t_currentScore);
        Maxcombotext.text = string.Format("{0:#,##0}", t_maxCombo);
        if (t_currentScore > 200000)
            KTH_RankManager.instance.Rank[0].SetActive(true);
        else
            KTH_RankManager.instance.Rank[1].SetActive(true);
    }
}
