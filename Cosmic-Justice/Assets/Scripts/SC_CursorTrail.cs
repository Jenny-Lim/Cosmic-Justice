using UnityEngine;

public class SC_CursorTrail : MonoBehaviour
{
    public Gradient trailColor;
    public float distanceFromCamera = 5;
    public float startWidth = 0.1f;
    public float endWidth = 0f;
    public float trailTime = 0.24f;
    public Material trailMaterial;

    [HideInInspector]
    public TrailRenderer trail;

    Transform trailTransform;
    Camera thisCamera;

    // Start is called before the first frame update
    void Start()
    {
        thisCamera = GetComponent<Camera>();

        GameObject trailObj = new GameObject("Mouse Trail");
        trailTransform = trailObj.transform;
        trail = trailObj.AddComponent<TrailRenderer>();
        trail.time = -1f;
        MoveTrailToCursor(Input.mousePosition);
        trail.time = trailTime;
        trail.startWidth = startWidth;
        trail.endWidth = endWidth;
        trail.numCapVertices = 2;
        trail.sharedMaterial = trailMaterial;
        trail.colorGradient = trailColor;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTrailToCursor(Input.mousePosition);
    }

    void MoveTrailToCursor(Vector3 screenPosition)
    {
        trailTransform.position = thisCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, distanceFromCamera));
    }
}