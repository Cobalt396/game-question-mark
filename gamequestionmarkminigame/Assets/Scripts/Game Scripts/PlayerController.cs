using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject dialogueController;
    private Animator playerAnim;
    Rigidbody playerRb;
    float horizontal;
    private Vector2 initialTransformPosition = new Vector2(-10, -1);
    private float speed = 10;
    private float jumpForce = 1400;
    private float xRange = 14;
    private float apothecaryDistanceAway = 50;
    private float switchSceneOffset = 3;
    private float lastPositionMagnitude;
    public bool switchedToApothecaryScene = false;
    public bool isOnGround = true;
    private bool textIsPlayed;
    private bool canContinue;
    private bool canBoost = true;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        transform.position = initialTransformPosition;
        lastPositionMagnitude = transform.position.magnitude;
        StartCoroutine(AnimationRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        //give variable values
        horizontal = Input.GetAxis("Horizontal");

        textIsPlayed = dialogueController.GetComponent<Dialogue>().GetTextIsPlayed();
        canContinue = dialogueController.GetComponent<Dialogue>().canContinue;

        if(Input.GetKeyDown(KeyCode.Q) && canBoost == true)
        {
            playerRb.AddForce(Vector2.right * speed * 100, ForceMode.Impulse);
            canBoost = false;
            StartCoroutine(CanBoostRoutine());
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && canBoost == true)
        {
            playerRb.AddForce(Vector2.right * speed * -100, ForceMode.Impulse);
            canBoost = false;
            StartCoroutine(CanBoostRoutine());
        }
        
        if(Input.GetKeyDown(KeyCode.S))
        {
            playerRb.AddForce(Vector2.down * Time.deltaTime * jumpForce * 100000 * Time.deltaTime, ForceMode.Impulse);
        }

        CheckJump();

        // creates left bound for home stage (should eventually incorporate this with below)
        if(transform.position.x < -xRange)
        {
            playerRb.AddForce(Vector2.right, ForceMode.VelocityChange);
        }

        // creates right bound for apothecary stage
        if(transform.position.x > apothecaryDistanceAway + xRange)
        {
            playerRb.AddForce(Vector2.left, ForceMode.VelocityChange);
        }

        // Switches the scenes
        if(transform.position.x > xRange && transform.position.x < apothecaryDistanceAway - switchSceneOffset - xRange)
        {
            if(switchedToApothecaryScene == false){
                transform.position = new Vector2(apothecaryDistanceAway - xRange, transform.position.y);
                switchedToApothecaryScene = true;
            } else {
                transform.position = new Vector2(xRange - switchSceneOffset, transform.position.y);
                switchedToApothecaryScene = false;
            }
        }

        // In case the MC falls through the floor
        if(transform.position.y < -2)
        {
            transform.position = new Vector2(transform.position.x, -1);
        }

        // Uncomment after dialogue is working
        // if(transform.position.x > xRange && canContinue == false)
        // {
        //     transform.position = new Vector2(xRange, transform.position.y);
        // }
    }

    void FixedUpdate()
    {
        Vector2 position = playerRb.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        playerRb.MovePosition(position);

        if (horizontal > 0 && !isFacingRight) {
            Flip();
        } else if (horizontal < 0 && isFacingRight) {
            Flip();
        }

    }

    IEnumerator AnimationRoutine()
    {
        playerAnim.SetFloat("Speed_f", Mathf.Abs(transform.position.magnitude - lastPositionMagnitude) / 0.1f);
        // Debug.Log(Mathf.Abs(transform.position.magnitude - lastPositionMagnitude) / 0.1f);
        lastPositionMagnitude = transform.position.magnitude;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(AnimationRoutine());
    }

    IEnumerator CanBoostRoutine()
    {
        yield return new WaitForSeconds(1);
        canBoost = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor") || (collision.gameObject.CompareTag("Platform")))
        {
            isOnGround = true;
        }
    }

    void CheckJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void Flip() {
        // Swap direction
        isFacingRight = !isFacingRight;

        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}
