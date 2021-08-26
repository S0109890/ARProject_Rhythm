using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KYU_judgeNEW : MonoBehaviour
{
    public GameObject Line;
    Ray ray;
 
    public int curCombo;
    public Text curComboText;
    MeshRenderer mas;
    //1. Ray를 쏘고
    //2. Ray와 Object의 거리를 측정하고
    //3. 그 거리에 따라서 판정을 한다.
    // Start is called before the first frame update
    void Start()
    {
        //Note = GameObject.FindWithTag("Note");
        //int layer = 1 << LayerMask.NameToLayer("Note");
        curComboText.text = string.Format("{0:#,##0}", curCombo);
        mas = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
        //ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo;
        if (Physics.Raycast(ray, out hitinfo))
        {
            print(hitinfo.transform.name);
                //좌클릭했을때 Note태그라면 지우자.
                //터치한 곳과 판정라인 거리를 측정하자
                if (Vector3.Distance(hitinfo.point, Line.transform.position) <= 0.6f && Vector3.Distance(hitinfo.point, Line.transform.position) >= -0.6f)
                {
                Destroy(GameObject.FindWithTag("Note"));
                    print("Perfect");
                    curCombo++;
                    curComboText.text = string.Format("{0:#,##0}", curCombo);
                    mas.material.color= Color.blue;

                }
                else if (Vector3.Distance(hitinfo.point, Line.transform.position) <= 0.8f && Vector3.Distance(hitinfo.point, Line.transform.position) >= -0.8f)
                {
                    print("Good");
                    curCombo++;
                    curComboText.text = string.Format("{0:#,##0}", curCombo);

                }
                else if (Vector3.Distance(hitinfo.point, Line.transform.position) <= 1f && Vector3.Distance(hitinfo.point, Line.transform.position) >= -1f)
                {
                    print("Ok");
                    curCombo=0;
                    curComboText.text = string.Format("{0:#,##0}", curCombo);

                }
                else
                {
                    print("Miss");
                    curCombo = 0;
                    curComboText.text = string.Format("{0:#,##0}", curCombo);

                }
            }
        }
    }
}
