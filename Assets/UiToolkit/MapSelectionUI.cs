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
    Label labelRank3;
    Label labelRank4;
    Label labelRank5;


    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        labelMap1Song = root.Q<Label>("LabelMap1Song");
        labelMap1Song.text = Globals.Instance.AllMaps[0].MapName;

        buttonMap1 = root.Q<Button>("ButtonMap1");
        buttonMap1.clicked += () => SelectMap();

        labelRank1 = root.Q<Label>("LabelRank1");
        labelRank2 = root.Q<Label>("LabelRank2");
        labelRank3 = root.Q<Label>("LabelRank3");
        labelRank4 = root.Q<Label>("LabelRank4");
        labelRank5 = root.Q<Label>("LabelRank5");
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
            labelRank1.text = $"{response[0].Rank}. {response[0].Username} - {response[0].Score}";
            labelRank2.text = $"{response[1].Rank}. {response[1].Username} - {response[1].Score}";
            labelRank3.text = $"{response[2].Rank}. {response[2].Username} - {response[2].Score}";
            labelRank4.text = $"{response[3].Rank}. {response[3].Username} - {response[3].Score}";
            labelRank5.text = $"{response[4].Rank}. {response[4].Username} - {response[4].Score}";
        });
    }

}
