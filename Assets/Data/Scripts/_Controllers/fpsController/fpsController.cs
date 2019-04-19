using UnityEngine;

public class fpsController : MonoBehaviour
{
    public float vSpeed = 6.0f;
    public float hSpeed = 3.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float forward = Input.GetAxis("Vertical") * vSpeed;
        float strafe = Input.GetAxis("Horizontal") * hSpeed;

        forward *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, forward);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
