using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    [SerializeField] private Button nextButton;

    // Start is called before the first frame update
    void Start()
    {
        nextButton.onClick.AddListener(Click);
    }

    private void Click()
    {
        EventManager.current.MouseClick();
    }
}
