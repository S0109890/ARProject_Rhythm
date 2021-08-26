using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//나의 앞 방향으로 1.5m 앞에 start spawn을 만들고 싶다.
public class LSM_SetStartPosition : MonoBehaviour
{
    public GameObject startFactory;
    public Transform parent;
    public GameObject start;
    // Start is called before the first frame update
    void Awake()
    {
    }

    public void CreateStart(float distance)
    {
        start = Instantiate(startFactory);
        start.transform.position = transform.position + start.transform.forward * distance;
        start.transform.parent = parent;
        start.GetComponent<LSM_Target>().target = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
