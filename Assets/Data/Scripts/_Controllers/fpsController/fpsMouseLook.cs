using UnityEngine;

public class fpsMouseLook : MonoBehaviour
{
    private Vector2 mouseLook;
    private Vector2 smoothV;
    private GameObject fpsCharacter;

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public float viewRange = 90.0f;

    private void Start()
    {
        fpsCharacter = transform.parent.gameObject;
    }

    private void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = (Quaternion.AngleAxis(Mathf.Clamp(-mouseLook.y, -viewRange, viewRange), Vector3.right));
        fpsCharacter.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, fpsCharacter.transform.up);
    }
}
