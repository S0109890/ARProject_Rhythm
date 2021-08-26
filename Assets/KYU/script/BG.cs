using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    // cache
    Material mat;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        // offset -> Material -> MeshRenderer
        // gameObject에게 MeshRenderer를 가져오고싶다. 
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        mat = renderer.material;

    }

    // Update is called once per frame
    void Update()
    {
        // P = P0 + vt
        mat.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
    }
}