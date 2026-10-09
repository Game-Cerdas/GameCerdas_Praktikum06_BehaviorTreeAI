using UnityEngine;

#if !ENABLE_LEGACY_INPUT_MANAGER && ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class SimplePlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

#if ENABLE_LEGACY_INPUT_MANAGER

        // ----------------------------------------------------
        // Versi modul (Input Manager lama).
        // Aktif jika Active Input Handling = "Input Manager (Old)"
        // atau "Both".
        // ----------------------------------------------------

        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.LeftArrow))
            horizontal = -1f;

        if (Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.RightArrow))
            horizontal = 1f;

        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.UpArrow))
            vertical = 1f;

        if (Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.DownArrow))
            vertical = -1f;

#elif ENABLE_INPUT_SYSTEM

        // ----------------------------------------------------
        // Versi Input System baru.
        // Aktif jika Active Input Handling = "Input System
        // Package (New)" saja, seperti default template
        // Universal 3D pada Unity 6.
        //
        // Tombolnya sama: WASD / arrow key.
        // ----------------------------------------------------

        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
            return;

        if (keyboard.aKey.isPressed ||
            keyboard.leftArrowKey.isPressed)
            horizontal = -1f;

        if (keyboard.dKey.isPressed ||
            keyboard.rightArrowKey.isPressed)
            horizontal = 1f;

        if (keyboard.wKey.isPressed ||
            keyboard.upArrowKey.isPressed)
            vertical = 1f;

        if (keyboard.sKey.isPressed ||
            keyboard.downArrowKey.isPressed)
            vertical = -1f;

#endif

        Vector3 direction =
            new Vector3(horizontal, 0f, vertical);

        if (direction.sqrMagnitude > 1f)
            direction.Normalize();

        transform.position +=
            direction * moveSpeed * Time.deltaTime;
    }
}
