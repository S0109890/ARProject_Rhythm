using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSM_LerpNote : MonoBehaviour
{
    public float maxDistantDelta = 0.004f;
    public Vector3 target;
    public float speed=0.0005f;
    public Collider col;
    //public GameObject target;
    //Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.LookAt(target);
        col = GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        //print(target);
        //Vector3 goTarget = target - transform.position;
        //transform.position += goTarget * Time.deltaTime * speed;
        transform.position += transform.forward * Time.deltaTime * speed;

        //transform.position = Vector3.MoveTowards(gameObject.transform.position, target, maxDistantDelta);
        //transform.position = Vector3.MoveTowards(gameObject.transform.position, pos, maxDistantDelta);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.name.Contains("j"))
        {
            col.enabled = false;
        }
    }
}
