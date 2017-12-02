using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour {

    static public Screenshake instance;
    public float duration = 0.01f;
    public float strenght = 0.1f;


    public static void FrameShake(Vector2 dir)
    {
        instance.StartCoroutine(instance.shake(dir));
    }

    public IEnumerator shake(Vector2 dir)
    {

        Camera.main.transform.position += (Vector3)dir * strenght;
        //Time.timeScale = 0.000001f;
        yield return new WaitForSecondsRealtime(duration);
        //Time.timeScale = 1;
        Camera.main.transform.position -= (Vector3)dir * strenght;
    }
    void Start()
    {
        instance = this;
    }
}
