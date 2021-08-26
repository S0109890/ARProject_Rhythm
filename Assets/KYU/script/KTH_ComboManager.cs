using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTH_ComboManager : MonoBehaviour
{
    public static KTH_ComboManager instance = null;

    private void Awake()
    {
        instance = this;
    }

    Animator myAnim;
    string animCombo = "Combo";
    public GameObject ImageCombo = null;
    public UnityEngine.UI.Text TextCombo = null;
    int currentCombo = 0;
    int maxCombo = 0;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        TextCombo.gameObject.SetActive(false);
        ImageCombo.SetActive(false);
    }
    public void IncreaseCombo(int p_num = 1)
    {
        currentCombo += p_num;
        TextCombo.text = string.Format("{0:#,##0}", currentCombo);

        if (maxCombo < currentCombo)
            maxCombo = currentCombo;

        if (currentCombo > 2)
        {
            TextCombo.gameObject.SetActive(true);
            ImageCombo.SetActive(true);
            myAnim.SetTrigger(animCombo);
        }
    }

    public int GetCurrentCombo()
    {
        return currentCombo;
    }

    public int GetMaxCombo()
    {
        return maxCombo;
    }

    public void ResetCombo()
    {
        currentCombo = 0;
        TextCombo.text = "0";
        TextCombo.gameObject.SetActive(false);
        ImageCombo.SetActive(false);
    }
}
