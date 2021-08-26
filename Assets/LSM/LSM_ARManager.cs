using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

// 카메라의 전방으로 Ray를 이용해서 닿은곳이 있다면 
// 그곳에 인디케이터를 가져다 놓고싶다.
// 그런데 만약 닿은곳이 없다면 인디케이터를 보이지않게 하고싶다.
// 인디케이터가 보이는 상황에서 화면을 터치해서 인디케이터를 선택하면
// 그 곳에 물체를 하나 생성해서 놓고싶다.
// - 인디케이터
// - 물체공장
public class LSM_ARManager : MonoBehaviour
{
    public static LSM_ARManager instance;

    public GameObject indicator;
    public GameObject gameFactory;

    public ARRaycastManager manager;
    Vector2 center;

    public GameObject unityMainCamera;

    public GameObject arSessionOrigin;
    public GameObject arSession;

    bool isGameStart;

    private void Awake()
    {
        instance = this;
#if UNITY_EDITOR
        unityMainCamera.SetActive(true);

        arSessionOrigin.SetActive(false);
        arSession.SetActive(false);
#else
        unityMainCamera.SetActive(false);

        arSessionOrigin.SetActive(true);
        arSession.SetActive(true);
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
        center = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        isGameStart = false;
    }

    // Update is called once per frame
    void Update()
    {


        // AR카메라용 
        if (isGameStart == false)
        {
            ARUpdateIndicator();
        }
        StartGame();
    }


    bool A = false;
    //*****ar버전 !!! ::
    private void StartGame()
    {
        //인디케이터가 보이는 상황에서(보이지앟는다면 리턴)
        if (indicator.activeSelf == false)
        { return; }

        // 1. 만약 핸드폰화면을 터치하면 **********************
        if (Input.GetMouseButtonDown(0))
        {
            // 2. 그 위치(Screen)에서 메인 카메라의 전방으로 시선을 만들고
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 바라보고
            RaycastHit hitInfo;
      
            if (Physics.Raycast(ray, out hitInfo, 100000/*, layer*/))
            {
                if (A == false)
                {  
                A = true;
                // 그 곳에 게임을 생성해서 놓고싶다.
                GameObject game = Instantiate(gameFactory);
                game.transform.position = hitInfo.point;
                    game.transform.forward = Camera.main.transform.forward;
                isGameStart = true;
                }
                


            }
        }
    }




    //*****ar버전 !!! ::
    private void ARUpdateIndicator()
    {
        // AR카메라를 이용해서 Ray로 바라보고싶다 
        List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
        if (manager.Raycast(center, hitResults))
        {
            // 만약 바라본곳에 닿은것이 있다면 
            Pose pose = hitResults[0].pose;
            indicator.SetActive(true);
            // 그곳에 인디케이터를 가져다 놓고싶다.
            indicator.transform.position = pose.position;
        
        }
        else
        {
            // 닿은곳이 없다면 인디케이터를 보이지않게 하고싶다.
            indicator.SetActive(false);
        }
    }
}