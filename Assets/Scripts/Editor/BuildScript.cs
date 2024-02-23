using UnityEditor;
using System.Diagnostics;

public class BuildScript
{
    static string[] scenes = { "Assets/Scenes/MainMenu.unity", "Assets/Scenes/GameScene.unity" };
    static string buildPath = "./Builds/";
    static string name = "RHTM.exe";

    [MenuItem("Build/Build Windows %t")]
    public static void BuildWindows()
    {
        // Build player.
        BuildPipeline.BuildPlayer(scenes, buildPath + name, BuildTarget.StandaloneWindows, BuildOptions.None);

        // Copy a file from the project folder to the build folder, alongside the built game.
        FileUtil.CopyFileOrDirectory("Maps", buildPath + "Maps");
    }
}
