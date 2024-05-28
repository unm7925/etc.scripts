using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Button()
    {
        Invoke("startgame", 3f);
    }
    void startgame()
    {
        SceneManager.LoadScene("0k");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
