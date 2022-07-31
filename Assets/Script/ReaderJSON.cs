using UnityEngine;
using Newtonsoft.Json;
using System.IO;

[System.Serializable]
public class Data
{
    public int id;
    public string title;
    public string content;
}

[System.Serializable]
public class DataList
{
    public Data[] data;
}

public class ReaderJSON : MonoBehaviour
{
    public DataList dataList_1 = new DataList();
    public DataList dataList_2 = new DataList();

    public DataList currentDataList;

    [SerializeField]
    private PanelJSON panelJSON;

    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/data.json");
        dataList_1 = JsonUtility.FromJson<DataList>("{\"data\":" + json + "}");

        json = File.ReadAllText(Application.dataPath + "/data 2.json");
        dataList_2 = JsonUtility.FromJson<DataList>("{\"data\":" + json + "}");

        /*
         * Series de test avec Newtonsoft
        string jsonStr = @"{ 'id' : '0', 'title' : 'title - id0', 'content' : 'Lorem ipsum dolor sit amet 0' }";
        var emp = JsonConvert.DeserializeObject<Data>(jsonStr);
        Debug.Log("id : " + emp.id + "\ntitle : " + emp.title + "\ncontent : " + emp.content);
        */
    }

    public void SetCurrentDataList(int indice)
    {
        if(indice == 1)
            currentDataList = dataList_1;
        else
            currentDataList = dataList_2;

        panelJSON.CreateJSONButtonTitle(currentDataList);
    }
}
