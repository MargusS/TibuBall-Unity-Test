using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float speed = 2.5f;
    float movementX;
    float movementY;
    private bool isJumping;
    private Vector3 startPosition;
    private int count;
    public TextMeshProUGUI countText,alertText;
    private int myScene;
    private System.Timers.Timer aTimer;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        startPosition = rigidBody.position;
        count = 0;
        myScene = SceneManager.GetActiveScene().buildIndex;
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = count.ToString() + " / 4";
    }
    void SetAlertText(string text)
    {
        alertText.text = text;
    }
    private void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
        rigidBody.mass = 0.5f;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Lumen"))
        {
            SoundManager.PlaySound("lumen");
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            SetAlertText("");
        }

        if (other.gameObject.CompareTag("next") )
        {
            if (count == 4)
            {
                changueScene();
            }
            else
            {
                SetAlertText("Pick up all items to continue ");
            }
        }
    }

    public void changueScene()
    {
        SoundManager.PlaySound("next");
        StartCoroutine("WaitFor");
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(1.5f);
        count = 0;
        if (myScene == 5)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(myScene + 1);
        }
        
    }

    private void LateUpdate()
    {
        if (rigidBody.position.y < -10)
        {
            rigidBody.position = startPosition;
            rigidBody.velocity = new Vector3(0, 0, 0);
        }
    }
    void Update()
    {
        rigidBody.AddForce(new Vector3(movementX*speed, 0.0f, movementY*speed));
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rigidBody.mass = 0.65f;
            rigidBody.velocity = new Vector3(0, 3.5f, 0);
            isJumping = true;
        }
    }
}
