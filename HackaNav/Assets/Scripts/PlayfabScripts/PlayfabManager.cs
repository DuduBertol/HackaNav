using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    [SerializeField] GameObject nameWindow;
    [SerializeField] GameObject nameEditWindow;
    [SerializeField] GameObject startScreenPanel;
     [SerializeField] GameObject tempPanel;
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TMP_InputField nameEditInput;
    [SerializeField] TextMeshProUGUI nameText;
    string loggedInPlayfabID;
    public GameObject rowPrefab;
    public Transform rowsParent;
    public Transform rowsParent2;

    //public PerfilData perfilData;
    int rank, highRank;
    [SerializeField] TextMeshProUGUI rankText, highRankText;

    void Start()
    {
        nameText.text = PlayerPrefs.GetString("NamePlayer");
        TempPanel();
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier, 
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSucces, OnError);
    }

    void OnLoginSucces(LoginResult result)
    {
        loggedInPlayfabID = result.PlayFabId;
        GetLeaderboard();
        GetLeaderboardAroundPlayer();
        Debug.Log("Sucesso em logar/registrar conta");
        string name = null;
        if(result.InfoResultPayload.PlayerProfile != null)
            name = result.InfoResultPayload.PlayerProfile.DisplayName;

        if(name == null)
            nameWindow.SetActive(true);
            
        else if(name != null)
        {
            nameWindow.SetActive(false);
        }
            
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Erro ao logar/registrar conta");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SubmitNameButton()
        {
            nameText.text = nameInput.text;
            PlayerPrefs.SetString("NamePlayer", nameText.text);

            var request = new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = nameInput.text,
            };
            PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
        }

    public void EditNameButton()
        {
            nameText.text = nameEditInput.text;
            PlayerPrefs.SetString("NamePlayer", nameText.text);

            var request = new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = nameEditInput.text,
            };
            PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
        }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Nome atualizado!");
        LeanTween.scale(nameWindow.GetComponent<RectTransform>(), new Vector3(0,0,0), 0.3f).setEaseOutExpo();
        LeanTween.scale(nameEditWindow.GetComponent<RectTransform>(), new Vector3(0,0,0), 0.3f).setEaseOutExpo();
        GetLeaderboard();
        GetLeaderboardAroundPlayer();
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "ResidualRank",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Sucesso ao enviar a leaderboard");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "ResidualRank",
            StartPosition = 0,
            MaxResultsCount = 10,
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in result.Leaderboard)
        {
            GameObject newGO = Instantiate(rowPrefab, rowsParent);
            TextMeshProUGUI[] texts = newGO.GetComponentsInChildren<TextMeshProUGUI>();
            Image[] image = newGO.GetComponentsInChildren<Image>();
            //image[0].sprite = perfilData.stateSprites[perfilData.stateID];
            //nameText.text = item.DisplayName;
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            if(item.PlayFabId == loggedInPlayfabID)
            {
                texts[0].color = Color.yellow;
                texts[1].color = Color.yellow;
                texts[2].color = Color.yellow;
                rank = (item.Position + 1);
            }
            rankText.text = rank.ToString();

            Debug.Log(item.Position + " | " + item.PlayFabId + " | " + item.StatValue);
        }
    }

    #region LEADERBOARD 2
    public void GetLeaderboardAroundPlayer()
    {
        var request = new GetLeaderboardAroundPlayerRequest()
        {
            StatisticName = "ResidualRank",
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }

    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        foreach(Transform item in rowsParent2)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in result.Leaderboard)
        {
            GameObject newGO = Instantiate(rowPrefab, rowsParent2);
            TextMeshProUGUI[] texts = newGO.GetComponentsInChildren<TextMeshProUGUI>();
            Image[] image = newGO.GetComponentsInChildren<Image>();
            //image[0].sprite = perfilData.stateSprites[perfilData.stateID];
            //nameText.text = item.DisplayName;
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            if(item.PlayFabId == loggedInPlayfabID)
            {
                texts[0].color = Color.yellow;
                texts[1].color = Color.yellow;
                texts[2].color = Color.yellow;
            }

            Debug.Log(item.Position + " | " + item.PlayFabId + " | " + item.StatValue);
        }
    }

    #endregion


    //meus métodos

    public void OpenNameScreen()
    {
        LeanTween.scale(nameWindow.GetComponent<RectTransform>(), new Vector3(1,1,1), 0.6f).setEaseInExpo();
        LeanTween.scale(startScreenPanel.GetComponent<RectTransform>(), new Vector3(0,0,0), 0.5f).setEaseOutExpo();
    }
    public void OpenEditName()
    {
        LeanTween.scale(nameEditWindow.GetComponent<RectTransform>(), new Vector3(1,1,1), 0.6f).setEaseInExpo();
    }
    public void CloseEditName()
    {
        LeanTween.scale(nameEditWindow.GetComponent<RectTransform>(), new Vector3(0,0,0), 0.6f).setEaseInExpo();
    }

    private void TempPanel()
    {
        LeanTween.moveLocalX(tempPanel, 540, 1f).setEaseInCubic().setOnComplete(TempPanel2);
    }

    private void TempPanel2()
    {
        LeanTween.moveLocalX(tempPanel, 1620, 1f).setDelay(2f).setEaseInCubic();
        Destroy(tempPanel, 4f);
    }
}
