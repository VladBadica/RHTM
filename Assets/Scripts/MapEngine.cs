using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RHTMGame;
using RHTMGame.Utils;

public class MapEngine : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Globals.Instance.CurrentMap.MapName);


        Globals.Instance.CurrentMap.Steps.ForEach(step =>
        {
            Debug.Log(step.y);
            if(prefab.TryGetComponent<Transform>(out var stepTransform))
            {
                Debug.Log("Instantiate");

                Instantiate(prefab, new Vector3(step.x, step.y, 0), stepTransform.rotation);
            }           
        });
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
