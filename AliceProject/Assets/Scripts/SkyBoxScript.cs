using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SkyBoxScript : MonoBehaviour
{
    public Material skyInitial;
    public Material skyEntrance;
    public Material skyExit;



    // Start is called before the first frame update
    void Start()
    {
        ChangeBackground();

    }

    // Update is called once per frame
    void Update()
    {
    }

    void ChangeBackground()
    {
        Scene scene = SceneManager.GetActiveScene();

        switch (scene.name)
        {
            case "Initial":
                RenderSettings.skybox = skyInitial;
                break;
            case "Entrance":
                RenderSettings.skybox = skyEntrance;
                break;
            case "Exit":
                RenderSettings.skybox = skyExit;
                break;
                    
        }

    }
}
