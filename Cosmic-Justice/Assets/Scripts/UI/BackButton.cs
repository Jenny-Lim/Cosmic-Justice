using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    private Button back;

    // Start is called before the first frame update
    void Start()
    {
        back = GetComponent<Button>();

        back.onClick.AddListener(BackClicked);
    }

    
    private void BackClicked()
    {
        SceneLoader.instance.MainMenu();
    }
}
