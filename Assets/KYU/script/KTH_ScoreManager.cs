using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class KTH_ScoreManager : MonoBehaviour
{
    public static KTH_ScoreManager instance = null;

    private void Awake()
    {
        instance = this;
    }

    public Text textHighScore;
    private int highscore;

    public int HighScore
    {
        get { return highscore; }
        set
        {
            highscore = value;
            textHighScore.text = "최고 : " + highscore + "점";
            PlayerPrefs.SetInt("HighScore", highscore);
        }
    }

    public Text textScore;
    private int score;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            textScore.text = "점수 : " + score + "점";
            if (score > highscore)
            {
                HighScore = score;
            }
        }
    }
    int increaseScore = 10;
    static int currentScore = 0;
    public int[] weight = null;
    public int comboBonusScore = 1;
    // Start is called before the first frame update
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        Score = 0;
    }
    public void IncreaseScore(int p_JudgementState)
    {
        // 콤보 증가
        KTH_ComboManager.instance.IncreaseCombo();

        int t_currentCombo = KTH_ComboManager.instance.GetCurrentCombo();
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;
        
        // 판정 가중치 계산
        int t_increaseScore = increaseScore + t_bonusComboScore;
        t_increaseScore = (int)(t_increaseScore * weight[p_JudgementState]);

        // 점수 반영
        currentScore += t_increaseScore;
        Score = currentScore;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
