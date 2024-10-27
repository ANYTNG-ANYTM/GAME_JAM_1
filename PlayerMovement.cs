using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controler;
    public Animator animator;

    float horizontalmove = 0f;
    bool jump = false;
    bool crouch = false;
    float timer = 0f;
    void Update()
    {

        horizontalmove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJump",true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }

        if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalmove));


        timer += Time.deltaTime;
        if (Mathf.Abs(horizontalmove) > 0.01 && timer > 0.35)
        {
            timer = 0f;
            FindObjectOfType<AudioManager>().Play("PlayerWalk");
        }

     }

    public void Onlanding()
    {
        animator.SetBool("IsJump",false);
    }

    public void OnCrouching(bool Crouching)
    {
        animator.SetBool("IsCrouch", Crouching);
    }

    private void FixedUpdate()
    {
        controler.Move(horizontalmove * Time.fixedDeltaTime * 20f, crouch, jump);
        jump = false;
    }
}
