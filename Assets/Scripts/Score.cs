using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Score : MonoBehaviour
{

    public static Score Instance;
    public string iplayer1;
    public string iplayer2;
    public string iplayer3;
    public string iplayer4;
    public string iplayer5;
    public string Name;
    public int ScorePlayer;
    public string inputName;
    public int inputScorePlayer;
    // new variable declared

    public struct PlayerStat
    {
        public string name;
        public int scorePlayer;    
    }
    public PlayerStat[] stat = new PlayerStat[5];
     
    private void Awake()
    {
        for (int i = 0; i < stat.Length; i++)
        {
            stat[i].name = "New player";
            stat[i].scorePlayer = 0;

        }
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
       LoadStat();
     }
    [System.Serializable]
    class SaveData
    {
        public string dplayer1;
        public string dplayer2;
        public string dplayer3;
        public string dplayer4;
        public string dplayer5;
        public int scorePlayer1;
        public int scorePlayer2;
        public int scorePlayer3;
        public int scorePlayer4;
        public int scorePlayer5;
    }

    public void SaveStat()
    {
        SaveData data = new SaveData();
        data.dplayer1 = stat[0].name;
        data.dplayer2 = stat[1].name;
        data.dplayer3 = stat[2].name;
        data.dplayer4 = stat[3].name;
        data.dplayer5 = stat[4].name;
        data.scorePlayer1 = stat[0].scorePlayer;
        data.scorePlayer2 = stat[1].scorePlayer;
        data.scorePlayer3 = stat[2].scorePlayer;
        data.scorePlayer4 = stat[3].scorePlayer;
        data.scorePlayer5 = stat[4].scorePlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadStat()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            stat[0].name = data.dplayer1;
            stat[1].name = data.dplayer2;
            stat[2].name = data.dplayer3;
            stat[3].name = data.dplayer4;
            stat[4].name = data.dplayer5;
            stat[0].scorePlayer = data.scorePlayer1;
            stat[1].scorePlayer = data.scorePlayer2;
            stat[2].scorePlayer = data.scorePlayer3;
            stat[3].scorePlayer = data.scorePlayer4;
            stat[4].scorePlayer = data.scorePlayer5;
            iplayer1 = $"1 :{stat[0].name} {stat[0].scorePlayer}";
            iplayer2 = $"2 :{stat[1].name} {stat[1].scorePlayer}";
            iplayer3 = $"3 :{stat[2].name} {stat[2].scorePlayer}";
            iplayer4 = $"4 :{stat[3].name} {stat[3].scorePlayer}";
            iplayer5 = $"5 :{stat[4].name} {stat[4].scorePlayer}";
        }
    }
    public void newPlayer (string PlayerName)
    {
        Name = PlayerName;
        ScorePlayer = 0;
    }
     public string getPlayer()
    {
        
        return Name;
    }
    public void BestPlayer(string inputName,int inputScorePlayer)
    {
        PlayerStat Low1,Low2;
        Low1.scorePlayer = 0;
        Low1.name = "";
        Low2.scorePlayer = 0;
        bool newPlayer= true;
        for (int i = 0; i < stat.Length; i++)
        {
            if (inputScorePlayer > stat[i].scorePlayer&&newPlayer)
            {
                Low1 = stat[i];
                stat[i].name = inputName;
                stat[i].scorePlayer = inputScorePlayer;
                newPlayer = false;
            }
            if (Low1.scorePlayer > stat[i].scorePlayer)
            {
                
                Low2 = stat[i];
                stat[i] = Low1;
                Low1 = Low2;
            }
        }
        iplayer1 = $"1 :{stat[0].name} {stat[0].scorePlayer}";
        iplayer2 = $"2 :{stat[1].name} {stat[1].scorePlayer}";
        iplayer3 = $"3 :{stat[2].name} {stat[2].scorePlayer}";
        iplayer4 = $"4 :{stat[3].name} {stat[3].scorePlayer}";
        iplayer5 = $"5 :{stat[4].name} {stat[4].scorePlayer}";
       SaveStat();
    }
    public string getBestPlayer()
    {

        return stat[0].name;
    }
    public int getBestPlayerScore()
    {

        return stat[0].scorePlayer;
    }

}