using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;

    [SerializeField]
    private float clickTreshold;
    [SerializeField]
    private float dragMultiply;
    [SerializeField]
    private float rotationSpeed;

    private Touch touch;

    private bool clickFlag;
    private bool hasGameStarted;
    private bool isJoystickActive;

    private Vector2 delta;
    private Vector2 clickCenter;
    private Vector2 direction2D;
    private Vector3 direction;
    private Vector3 targetDirection;

    private Quaternion targetRotation;

    [SerializeField]
    private float MovementSpeed;



    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        direction = Vector3.zero;
        targetDirection = Vector3.zero;

        clickFlag = false;
        hasGameStarted = false;
        isJoystickActive = false;
    }

    private void Update()
    {
        if (hasGameStarted)
        {
            if (GameManager.Instance.IsGameOn)
            {
                if (Input.touches.Length > 0)
                {
                    touch = Input.touches[0];
                    delta = touch.deltaPosition;

                    if (touch.phase == TouchPhase.Began)
                    {
                        clickFlag = true;
                        isJoystickActive = false;
                    }
                    else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                    {
                        if (clickFlag)
                        {
                            clickCenter = touch.position;

                            clickFlag = false;
                            isJoystickActive = true;

                            // TO DO -> Enable walk animation here.
                        }

                        if (delta.magnitude > clickTreshold)
                        {
                            direction2D = touch.position - clickCenter;
                            direction = new Vector3(direction2D.x, 0.0f, direction2D.y);
                            direction = Vector3.Normalize(direction);
                        }
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        if (delta.magnitude < clickTreshold && clickFlag)
                        {
                            Click(touch);
                        }

                        clickFlag = false;
                        isJoystickActive = false;

                        // TO DO -> Disable walk animation here.
                    }
                }
                else
                {
                    // TO DO -> Disable walk animation here.

                    direction = transform.forward;
                }
            }
        }
        else
        {
            if (Input.touches.Length > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    hasGameStarted = true;

                    // TO DO -> Implement "Tap to Play" here.
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.IsGameOn)
        {
            transform.rotation = Quaternion.LookRotation(direction);

            if (isJoystickActive)
            {
                direction.y = 0f;
                rigidbody.velocity = direction * MovementSpeed * Time.fixedDeltaTime;
            }
        }
    }

    private void Click(Touch touch)
    {

    }


}
