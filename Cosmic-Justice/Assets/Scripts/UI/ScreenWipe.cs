using UnityEngine;
using UnityEngine.UI;

public class ScreenWipe : MonoBehaviour
{
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

    private Image image;

    private enum WipeMode { NotBlocked, WipingToNotBlocked, Blocked, WipingToBlocked }

    private WipeMode wipeMode = WipeMode.Blocked;

    private float wipeProgress = 1f;

    public bool isDone { get; private set; }


    private void Awake()
    {
        image = GetComponentInChildren<Image>();

        SetFillMethod();

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ToggleWipe(false);
    }

    private void SetFillMethod()
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
    

    public void ToggleWipe(bool blockScreen)
    {
        isDone = false;
        if (blockScreen)
            wipeMode = WipeMode.WipingToBlocked;
        else
            wipeMode = WipeMode.WipingToNotBlocked;

        // Reset wipeProgress based on the mode
        if (wipeMode == WipeMode.WipingToNotBlocked)
            wipeProgress = 1.0f;
        else if (wipeMode == WipeMode.WipingToBlocked)
            wipeProgress = 0.0f;
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
            isDone = true;
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
            wipeMode = WipeMode.NotBlocked;
        }
    }

    [ContextMenu("Block")]
    private void Block() { ToggleWipe(true); }
    [ContextMenu("Clear")]
    private void Clear() { ToggleWipe(false); }

}