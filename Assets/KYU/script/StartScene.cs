using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartScene : MonoBehaviour
{
    enum State
    {
        Wait,
        Play
    }
    State state;
    public Image whiteFade;
    public RawImage rawWhiteFade;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Wait;
        whiteFade.canvasRenderer.SetAlpha(0.0f);
        rawWhiteFade.canvasRenderer.SetAlpha(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            state = State.Play;
        }
        if (state == State.Play)
        {
            whiteFade.CrossFadeAlpha(1.0f, speed, false);
            rawWhiteFade.CrossFadeAlpha(0.0f, speed, false);

            if (speed > 0)
            {
                speed -= Time.deltaTime;
                if (speed <= 0)
                {
                    print("1111111111111111");
                    SceneManager.LoadScene("SelectScene");
                }
            }
        }
    }
}

