using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSystem : MonoBehaviour
{
    //Movements Variables
    public float _moveSpeed = 7f;

    //Health Variables
    public float playerHealth;
    public float maxPlayerHealth = 100f;
    EnemySystem _takeHit;
    public TextMesh hpText;

    //Inputs
    private float xInp;
    private float yInp;

    //Physics
    Rigidbody2D rb;
    public Camera cam;

    //Vectors
    public Vector2 mousePos;
    public Vector2 lookDir;


    void Awake()
    {
       rb = GetComponent<Rigidbody2D>(); 
       hpText = GetComponent<TextMesh>();
    }

    void Start()
    {
        playerHealth = maxPlayerHealth;
    }

    void Update()
    {
        playerRotate();
        hpText.text = $"{playerHealth} / {maxPlayerHealth}";
    }
    
    void FixedUpdate()
    {
        Movement();
    }


    void Movement()
    {
        xInp = Input.GetAxis("Horizontal");
        yInp = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(xInp * _moveSpeed,yInp * _moveSpeed,0f);
    }

    void playerRotate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    
}
