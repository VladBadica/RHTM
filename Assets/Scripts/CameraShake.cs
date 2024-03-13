using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float defaultFoV = 77.3f;
    public Camera cam;

    public void Start()
    {
        cam.fieldOfView = defaultFoV;
    }

    public IEnumerator Shake(float duration, float multiplier)
    {
        var elapsed = 0.0f;

        while(elapsed < duration)
        {
            var target = elapsed > duration / 2 ? defaultFoV : defaultFoV / multiplier;
            ZoomCamera(target, multiplier);

            elapsed += Time.deltaTime;

            yield return null;
        }
    }

    void ZoomCamera(float target, float multiplier)
    {
        float angle = Mathf.Abs((defaultFoV / multiplier) - defaultFoV);
        cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / Time.deltaTime);
    }
}
