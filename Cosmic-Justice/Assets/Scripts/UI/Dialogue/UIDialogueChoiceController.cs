using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDialogueChoiceController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_Choice;
    [SerializeField]
    protected DialogueChannel m_DialogueChannel;
    [SerializeField]
    private Sprite m_ButtonSprite;
    [SerializeField]
    private TMP_FontAsset m_Font;
    [SerializeField]
    private Color m_FontColor;

    protected DialogueNode m_ChoiceNextNode;
    private TextMeshProUGUI text;
    private Image image;

    public DialogueChoice Choice
    {
        set
        {
            m_ChoiceNextNode = value.ChoiceNode;

            m_Font = value.Font;
            m_ButtonSprite = value.ButtonSprite;
            m_FontColor = value.FontColor;

            text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            image = gameObject.GetComponent<Image>();

            if (m_ButtonSprite != null && m_Font != null)
            {

                if (!SettingsSaver.instance.IsStandardized)
                {
                    //If not a verdict button
                    m_Choice.text = value.ChoicePreview;
                    text.font = m_Font;
                    image.sprite = m_ButtonSprite;
                    text.color = m_FontColor;

                    if (GetComponent<VerdictButton>() == null) { 
                        if (text.color.a == 0)
                            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                    }
                    else
                    {
                        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                    }
                }
                else
                {
                    m_Choice.text = value.ChoicePreview;
                    text.font = SettingsSaver.instance.standardizedFont;
                    text.color = Color.black;

                    if (text.color.a == 0)
                        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                }
            }
            else
            {
                Debug.Log("Please place a button sprite, font, and font color for the choice buttons at this choice node");
            }
        }
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        // only do this if not verdict -- overriden
        m_DialogueChannel.RaiseRequestDialogueNode(m_ChoiceNextNode);
    }
}