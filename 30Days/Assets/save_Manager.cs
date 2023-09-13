using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_Manager : MonoBehaviour
{
    save_data current_state;
    // Start is called before the first frame update
    void Start()
    {
        load_data();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            save_data();
        }
    }

    void load_data()
    {
        string data;
        if (FileManager.LoadFromFile("last_saved.json", out data))
        {
            current_state = JsonUtility.FromJson<save_data>(data);
        }
        else
        {
            current_state = new save_data();
            current_state.day = 0;
            current_state.money = 0;
            current_state.farm = new int[farm_manager.instance.height,farm_manager.instance.width];
            current_state.play_postion = FindObjectOfType<charactorController>().transform.position;
            current_state.seed = 0;
            string json = JsonUtility.ToJson(current_state);
            FileManager.WriteToFile("last_saved.json", json);
        }

        farm_manager.instance.day = current_state.day;
        farm_manager.instance.money = current_state.money;
        farm_manager.instance.farm_state = current_state.farm;
        FindObjectOfType<charactorController>().seed = current_state.seed;
        FindObjectOfType<charactorController>().transform.position = current_state.play_postion;
    }

    public void save_data()
    {
        current_state.day = farm_manager.instance.day;
        current_state.money = farm_manager.instance.money;
        current_state.farm = farm_manager.instance.farm_state;
        current_state.play_postion = FindObjectOfType<charactorController>().transform.position;
        current_state.seed = FindObjectOfType<charactorController>().seed;
        string json = JsonUtility.ToJson(current_state);
        FileManager.WriteToFile("last_saved.json", json);
    }
}
