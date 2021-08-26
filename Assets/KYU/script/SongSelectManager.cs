using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class SongSelectManager : MonoBehaviour
{

    public RawImage RawA;
    public RawImage RawB;
    public VideoClip vc;
    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        var vc = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // RawA가 보이고, RawB가 안보이고
            RawA.gameObject.SetActive(true);
            RawB.gameObject.SetActive(false);
            num = 1;
            print(num);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // RawB가 보이고, RawA가 안보이고
            RawB.gameObject.SetActive(true);
            RawA.gameObject.SetActive(false);
            num = 0;
            print(num);
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && num == 0 )
        {
            SceneManager.LoadScene("LaScene");
            print(num);
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) && num == 1 )
        {
            SceneManager.LoadScene("FreedomdiveScene");
            print(num);
        }
    }
}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class SongSelectManager : MonoBehaviour
//{
//    public RawImage[] RawImage;
//    int index;
//    enum KeyDirection
//    {
//        zero = 0,
//        right = 1,
//        left = -1
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        UpdateImage(KeyDirection.zero);
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.LeftArrow))
//        {
//            UpdateImage(KeyDirection.right);
//        }
//        if (Input.GetKeyDown(KeyCode.RightArrow))
//        {
//            UpdateImage(KeyDirection.left);
//        }
//    }

//    void UpdateImage(KeyDirection next)
//    {
//        index += (int)next;
//        if (index >= RawImage.Length)
//            index = 0;
//        else if (index < 0)
//            index = RawImage.Length - 1;

//        for (int i = 0; i < RawImage.Length; i++)
//        {
//            RawImage[i].gameObject.SetActive(index == i);
//        }
//    }
//}
