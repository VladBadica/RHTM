using RHTMGame;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using RHTMGame.Utils;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadAllMaps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadAllMaps()
    {
        Globals.Instance.AllMaps = new List<Map>();
        string[] mapFiles = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\Maps");
        for (int i = 0; i < mapFiles.Length; i++)
        {
            Globals.Instance.AllMaps.Add(JsonUtility.FromJson<Map>(File.ReadAllText(mapFiles[i])));
        }
    }
}
