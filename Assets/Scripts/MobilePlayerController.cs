using UnityEngine;
using UnityEngine.UI;

public class MobilePlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Joystick joystick;
    public Button jumpButton;
    public Button fireButton;

    public float runSpeed = 40f;

    bool jump = false;
    bool isTriggered = false;

    private float horizontalMove = 0f;


    private void Start()
    {
        jumpButton.onClick.AddListener(OnJumpButtonClick);
        fireButton.onClick.AddListener(OnFireButtonClick);
    }

    private void OnJumpButtonClick()
    {
        jump = true;
    }

    private void OnFireButtonClick()
    {
        isTriggered = !isTriggered;
        animator.SetBool("isTriggered", isTriggered);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object should be deleted
        if (other.CompareTag("ObjectToDelete"))
        {
            // Destroy the collided object
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        float horizontalInput = joystick.Horizontal;
        horizontalMove = horizontalInput * runSpeed;

        animator.SetFloat("Run", Mathf.Abs(horizontalMove));
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
