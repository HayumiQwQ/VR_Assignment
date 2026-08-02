using System;
using UnityEngine;

public class RTclock : MonoBehaviour
{
    public Transform hourHandPivot;
    public Transform minuteHandPivot;
    public Transform secondHandPivot;

    void Update()
    {
        DateTime now = DateTime.Now;

        float hourAngle = (now.Hour % 12) * 30f + now.Minute * 0.5f;
        float minuteAngle = now.Minute * 6f + now.Second * 0.1f;
        float secondAngle = now.Second * 6f;

        hourHandPivot.localRotation = Quaternion.Euler(hourAngle, 0f, 0f);
        minuteHandPivot.localRotation = Quaternion.Euler(minuteAngle, 0f, 0f);
        secondHandPivot.localRotation = Quaternion.Euler(secondAngle, 0f, 0f);
    }
}