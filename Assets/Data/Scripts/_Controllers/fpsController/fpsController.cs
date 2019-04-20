using UnityEngine;

public class fpsController : MonoBehaviour
{
    // Player default forward speed (controls speed when travelling forward and backwards)
    public float fSpeedDefault = 6.0f;
    // Player current forward speed
    public float fSpeedCurrent = 6.0f;
    // Value for backwards speed (causes player to slow when travelling backwards)
    public float bSpeedMod = 3.0f;
    // Player horizontal speed (controls speed when travelling left and right)
    public float hSpeed = 3.0f;
    // Player jump power (force with which the player jumps)
    public float jPower = 250.0f;

    // The rigidbody component attached to the player (used for physics)
    private Rigidbody myRigidbody;

    private void Start()
    {
        // Locks the cursor so that it doesn't appear on screen
        Cursor.lockState = CursorLockMode.Locked;

        // Populates the myRigidbody value with the actual rigidbody component on the game object
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Takes player input (between -1 and 1) and multiplies it by relevant speed value and deltaTime
        float forward = Input.GetAxis("Vertical") * (fSpeedCurrent * Time.deltaTime);
        float horizontal = Input.GetAxis("Horizontal") * (hSpeed * Time.deltaTime);

        // Slows the player down if travelling backwards then resets their speed if travelling forward
        if (Input.GetAxis("Vertical") < 0)
            fSpeedCurrent = bSpeedMod;
        else
            fSpeedCurrent = fSpeedDefault;

        // Translates the player transform along the X and Z axis using the forward and horizontal values
        transform.Translate(horizontal, 0, forward);
                       
        // Allows the player to jump when the Jump button is pressed
        if (Input.GetButtonDown("Jump"))
            myRigidbody.AddForce(0, jPower, 0);

        // Unlocks the cursor to access the editor menus when the player presses the escape key
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
