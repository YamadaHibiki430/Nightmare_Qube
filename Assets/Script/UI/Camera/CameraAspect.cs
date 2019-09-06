using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    [SerializeField]
    private float m_width = 1080;
    [SerializeField]
    private float m_height = 1920;

    void Awake()
    {
        Camera cam = gameObject.GetComponent<Camera>();
        float baseAspect = m_height / m_width;
        float nowAspect = (float)Screen.height / (float)Screen.width;
        float changeAspect;

        if (baseAspect > nowAspect)
        {
            changeAspect = nowAspect / baseAspect;
            cam.rect = new Rect((1 - changeAspect) * 0.5f, 0, changeAspect, 1);
        }
        else
        {
            changeAspect = baseAspect / nowAspect;
            cam.rect = new Rect(0, (1 - changeAspect) * 0.5f, 1, changeAspect);
        }
        Destroy(this);
    }
}
