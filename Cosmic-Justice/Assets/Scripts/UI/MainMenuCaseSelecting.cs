using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCaseSelecting : MonoBehaviour
{
    [SerializeField] private Button case1;
    [SerializeField] private Button case2;
    [SerializeField] private Button case3;

    // Start is called before the first frame update
    void Start()
    {
        case1.onClick.AddListener(Case1Clicked);
        case2.onClick.AddListener(Case2Clicked);
        case3.onClick.AddListener(Case3Clicked);
    }

    private void Case1Clicked()
    {
        SceneLoader.instance.LevelOne();
    }

    private void Case2Clicked()
    {
        SceneLoader.instance.LevelTwo();
    }

    private void Case3Clicked()
    {
        SceneLoader.instance.LevelThree();
    }
}
