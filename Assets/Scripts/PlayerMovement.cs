using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 10f;
    public float speed = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Vector3 initialPosition;  // Nueva variable para la posición inicial
    public float fallThreshold = -10f;  // Nueva variable para el umbral de caída

    private Rigidbody2D rb;
    private float horizontal;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;  // Guarda la posición inicial del personaje
    }

    void Update()
    {
        // Solo utilizar el valor de horizontal desde Input si no estamos ejecutando pruebas
        if (!isTesting)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Jump();
        }

        CheckFall();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        
        // Imprimir mensaje de salto para depuración
        Debug.Log("Jumping with force: " + jumpForce);
    }

    private void CheckFall()
    {
        if (transform.position.y < fallThreshold)
        {
            // Imprimir mensaje de caída para depuración
            Debug.Log("Player fell below threshold, resetting position.");
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.position = initialPosition;
        rb.velocity = Vector2.zero;  // Resetea la velocidad del personaje
    }

    // Nueva variable para controlar si estamos en modo de prueba
    private bool isTesting = false;

    // Nuevo método para establecer la entrada horizontal desde las pruebas
    public void SetHorizontalInput(float value)
    {
        isTesting = true;
        horizontal = value;
    }
}
