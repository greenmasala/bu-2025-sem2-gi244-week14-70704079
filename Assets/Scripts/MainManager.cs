using System.IO;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class MainManager : MonoBehaviour
{
    private static MainManager instance;
    public static MainManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    public Color TeamColor = Color.white;

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;
        JsonUtility.ToJson(data);
        string j = JsonUtility.ToJson(data);

        string p = Application.persistentDataPath; //"C:\\Users\\Administrator\\Desktop";
        string fileName = "saveData.json";
        string fullPath = Path.Combine(p, fileName);

        File.WriteAllText(fullPath, j);
        Debug.Log(fullPath);

        //Debug.Log(j);
        //PlayerPrefs.SetString("saveData", j); 

        //PlayerPrefs.SetFloat("teamColor.a", TeamColor.a); //saving alpha, red, green and blue values
        //PlayerPrefs.SetFloat("teamColor.r", TeamColor.r);
        //PlayerPrefs.SetFloat("teamColor.g", TeamColor.g);
        //PlayerPrefs.SetFloat("teamColor.b", TeamColor.b);
    }

    public void LoadColor()
    {
        string p = Application.persistentDataPath; //"C:\\Users\\Administrator\\Desktop";
        string fileName = "saveData.json";
        string fullPath = Path.Combine(p, fileName);


        //string j = PlayerPrefs.GetString("saveData");
        string j = File.ReadAllText(fullPath);
        Debug.Log(j);
        SaveData data = JsonUtility.FromJson<SaveData>(j);
        TeamColor = data.TeamColor;

        //TeamColor.a = PlayerPrefs.GetFloat("teamColor.a", 1f); //float val is default val
        //TeamColor.r = PlayerPrefs.GetFloat("teamColor.r", 1f);
        //TeamColor.g = PlayerPrefs.GetFloat("teamColor.g", 1f);
        //TeamColor.b = PlayerPrefs.GetFloat("teamColor.b", 1f);
    }
}
