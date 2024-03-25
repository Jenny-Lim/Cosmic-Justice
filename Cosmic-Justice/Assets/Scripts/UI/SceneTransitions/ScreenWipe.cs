using UnityEngine;
using UnityEngine.UI;

public class ScreenWipe : MonoBehaviour
{
    [SerializeField] private WipeData[] data;
    public WipeData[] Data => data;

    public enum FillMethod 
    {
        Horizontal,
        Vertical,
        Radial90,
        Radial180,
        Radial360,
    }

    public FillMethod fillMethod = FillMethod.Horizontal;

    [SerializeField] [Range(0.1f, 3f)] private float wipeSpeed = 1f;
    public float WipeSpeed => wipeSpeed;

    private Image image;

    private enum WipeMode { NotBlocked, WipingToNotBlocked, Blocked, WipingToBlocked }

    private WipeMode wipeMode = WipeMode.Blocked;

    private float wipeProgress = 1f;

    public bool isDone { get; private set; }

    public static ScreenWipe instance;

    private void Awake()
    {
        image = GetComponentInChildren<Image>();

        SetFillMethod();

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ToggleWipe(false);
    }

    public void SetFillMethod()
    {
        if(image != null)
        {
            switch(fillMethod)
            {
                case FillMethod.Horizontal:
                    image.fillMethod = Image.FillMethod.Horizontal;
                    break;
                case FillMethod.Vertical:
                    image.fillMethod = Image.FillMethod.Vertical;
                    break;
                case FillMethod.Radial90:
                    image.fillMethod = Image.FillMethod.Radial90;
                    break;
                case FillMethod.Radial180:
                    image.fillMethod = Image.FillMethod.Radial180;
                    break;
                case FillMethod.Radial360:
                    image.fillMethod = Image.FillMethod.Radial360;
                    break;
            }

            image.fillAmount = 1; // Fully blocked initially
        }
    }

    private void SetBtnsInteractable(bool val) // Jenny
    {
        Button[] btnList = Object.FindObjectsOfType<Button>();
        foreach (Button btn in btnList)
        {
            btn.interactable = val;
        }

        // tween
        OnPointerTween[] tweenList = Object.FindObjectsOfType<OnPointerTween>();
        foreach (OnPointerTween tween in tweenList)
        {
            tween.enabled = val;
            Debug.Log("tween: " + tween.enabled);
        }
        
    }

    public void ToggleWipe(bool blockScreen)
    {
        isDone = false;
        SetBtnsInteractable(isDone);
        if (blockScreen)
        {
            wipeMode = WipeMode.WipingToBlocked;
            wipeProgress = 0.0f; // The wipe starts from clear and moves to blocked
        }
        else
        {
            wipeMode = WipeMode.WipingToNotBlocked;
            wipeProgress = 1.0f; // The wipe starts from blocked and moves to clear
        }
    }
    
    private void Update()
    {
        switch(wipeMode)
        {
            case WipeMode.WipingToBlocked:
                WipeToBlocked();
                break;
            case WipeMode.WipingToNotBlocked:
                WipeToNotBlocked();
                break;
        }
    }

    private void WipeToBlocked()
    {
        wipeProgress += Time.deltaTime * (1f / wipeSpeed);
        image.fillAmount = wipeProgress;
        if (wipeProgress >= 1f)
        {
            EventManager.current.SceneWipe();
            isDone = true;
            SetBtnsInteractable(isDone);
            wipeMode = WipeMode.Blocked;
        }
    }

    private void WipeToNotBlocked()
    {
        wipeProgress -= Time.deltaTime * (1f / wipeSpeed);
        image.fillAmount = wipeProgress;
        if (wipeProgress <= 0)
        {
            isDone = true;
            SetBtnsInteractable(isDone);
            wipeMode = WipeMode.NotBlocked;
        }
    }

    [ContextMenu("Block")]
    private void Block() { ToggleWipe(true); }
    [ContextMenu("Clear")]
    private void Clear() { ToggleWipe(false); }

}