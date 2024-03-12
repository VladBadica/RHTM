using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float defaultFoV = 77.3f;
    private float zoomMultiplier = 2;
    private float zoomDuration = 2;
    public Camera cam;

    public void Start()
    {
        cam.fieldOfView = defaultFoV;
    }

    public IEnumerator Shake(float duration)
    {
        var elapsed = 0.0f;

        while(elapsed < duration)
        {
            ZoomCamera(elapsed > duration / 2 ? defaultFoV : defaultFoV / zoomMultiplier);

            elapsed += Time.deltaTime;

            yield return null;
        }
    }

    void ZoomCamera(float target)
    {
        float angle = Mathf.Abs((defaultFoV / zoomMultiplier) - defaultFoV);
        cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / zoomDuration * Time.deltaTime);
    }
}
