using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성이 보장
    public static Managers Instance { get { init();  return s_instance; } } // 유일한 매니저를 갖고온다
    // Start is called before 0the first frame update
    void Start()
    {
        // 초기화
        GameObject go = GameObject.Find("@Managers");
        s_instance = go.GetComponent<Managers>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void init() {
        if (s_instance == null) {
            GameObject go = GameObject.Find("@Managers");
            if (go == null) {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
}
