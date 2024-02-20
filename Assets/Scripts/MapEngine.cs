using UnityEngine;
using RHTMGame.Utils;

public class MapEngine : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Globals.Instance.CurrentMap.MapName);

        for(var i = 0; i < Globals.Instance.CurrentMap.Steps.Count; i++)
        {
            var step = Globals.Instance.CurrentMap.Steps[i];
            Debug.Log(step.y);
            if (prefab.TryGetComponent<Transform>(out var stepTransform))
            {
                Debug.Log("Instantiate");

                var stepObj = Instantiate(prefab, new Vector3(step.x, step.y, 0), stepTransform.rotation);

                if(stepObj.TryGetComponent<StepCollision>(out var stepCollision))
                {
                    stepCollision.StepNumber = i;
                    if (i == 0)
                    {
                        stepCollision.enabled = true;
                    }
                }
            }
        }           
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
