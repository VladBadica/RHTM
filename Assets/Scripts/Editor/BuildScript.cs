using UnityEditor;
using System.Diagnostics;
using System.IO;

public class BuildScript
{
    static string[] scenes = { "Assets/Scenes/MainMenu.unity", "Assets/Scenes/GameScene.unity" };
    static string buildPath = "./Builds/";
    static string name = "RHTM.exe";

    [MenuItem("Build/Build Windows &t")]
    public static void BuildWindows()
    {
        // Build player.
        BuildPipeline.BuildPlayer(scenes, buildPath + name, BuildTarget.StandaloneWindows, BuildOptions.None);

        // Copy a file from the project folder to the build folder, alongside the built game.
        CopyOrReplace("Maps");
    }

    [MenuItem("Build/Build And Run Windows &y")]
    public static void BuildAndRunWindows()
    {
        BuildWindows();

        Process proc = new Process();
        proc.StartInfo.FileName = Directory.GetCurrentDirectory() + buildPath + name;

        proc.Start();
    }

    private static void CopyOrReplace(string sourceDir)
    {
        if (!Directory.Exists(buildPath + sourceDir))
        {
            FileUtil.CopyFileOrDirectory(sourceDir, buildPath + sourceDir);
        }
        else
        {
            FileUtil.ReplaceDirectory(sourceDir, buildPath + sourceDir);
        }
    }
}
