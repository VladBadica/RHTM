using RHTMGame.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Dan;
using Dan.Main;

public class MapSelectionUI : MonoBehaviour
{
    VisualElement root;
    Label labelMap1Song;
    Button buttonMap1;
    Label labelRank1;
    Label labelRank2;


    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        labelMap1Song = root.Q<Label>("LabelMap1Song");
        labelMap1Song.text = Globals.Instance.AllMaps[0].MapName;

        buttonMap1 = root.Q<Button>("ButtonMap1");
        buttonMap1.clicked += () => SelectMap();


        labelRank1 = root.Q<Label>("LabelRank1");
        labelRank2 = root.Q<Label>("LabelRank2");
        GetLeaderboard();
    }

    private void SelectMap()
    {
        Globals.Instance.CurrentMap = Globals.Instance.AllMaps[0];
        SceneManager.LoadScene("Game");
    }

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(Globals.Instance.PublicLeaderboardKey, (response) =>
        {
            labelRank1.text = $"{response[0].Username}: {response[0].Score}";
            labelRank2.text = $"{response[1].Username}: {response[1].Score}";
        });
    }

}
