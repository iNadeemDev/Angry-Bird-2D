using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public Vector3 Initial_Position;
    public int Speed;
    public string Scene_Name;
    private bool isBirdFired;
    private float birdWaitTime;

    
    private Rigidbody2D Rigidbody;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Initial_Position = transform.position;
        AudioManager.instance.PlayMySound("start");
    }

    public void OnMouseDown()
    {
        spriteRenderer.color = Color.red;
        AudioManager.instance.PlayMySound("end");
    }
    public void OnMouseUp()
    {
        Vector3 Spring_Force = Initial_Position - transform.position;
        spriteRenderer.color = Color.white;
        Rigidbody.gravityScale = 1;

        Rigidbody.AddForce(Speed * Spring_Force);
        isBirdFired = true;
        AudioManager.instance.PlayMySound("end");

        // increment the attempt
        ScoreBoard.GetInstance().AddAttempts(1);
        ScoreBoard.GetInstance().AddScore(-10);

    }
    public void OnMouseDrag()
    {
        Vector3 DragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(DragPosition.x, DragPosition.y);

    }
    public void Update()
    {
        if(isBirdFired && Rigidbody.velocity.magnitude <= 0.5)
        {
            birdWaitTime += Time.deltaTime;
        }
        if(transform.position.x > 15 || transform.position.x < -15 || transform.position.y > 15 || transform.position.y < -15 || birdWaitTime > 2)
        {
            ResetObjectState();
        }
    }
    public void ResetObjectState()
    {
        //SceneManager.LoadScene(Scene_Name);
        transform.position = Initial_Position;
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.gravityScale = 0;
        Rigidbody.transform.rotation = Quaternion.identity;
        Rigidbody.angularVelocity = 0;
        birdWaitTime = 0;
        isBirdFired = false;
    }
}
