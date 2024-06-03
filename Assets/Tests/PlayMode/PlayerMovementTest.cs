using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTests
{
    private GameObject player;
    private PlayerMovement playerMovement;
    private Rigidbody2D rb;

    [SetUp]
    public void Setup()
    {
        // Crear un objeto de juego para el jugador
        player = new GameObject();
        player.AddComponent<Rigidbody2D>();
        rb = player.GetComponent<Rigidbody2D>();
        playerMovement = player.AddComponent<PlayerMovement>();

        // Configurar groundCheck
        GameObject groundCheck = new GameObject();
        playerMovement.groundCheck = groundCheck.transform;

        // Establecer una capa de terreno de prueba
        playerMovement.groundLayer = LayerMask.GetMask("Ground");
    }

    [TearDown]
    public void Teardown()
    {
        if (Application.isPlaying)
        {
            Object.Destroy(player);
        }
        else
        {
            Object.DestroyImmediate(player);
        }
    }

    [UnityTest]
    public IEnumerator Jump_WhenGrounded_ShouldIncreaseVerticalVelocity()
    {
        // Simular que el jugador está en el suelo
        playerMovement.groundCheck.position = player.transform.position;
        playerMovement.jumpForce = 10f;

        // Simular la entrada del jugador
        playerMovement.Jump();

        // Esperar un cuadro para que se llame a Update
        yield return null;

        // Verificar que la velocidad vertical ha aumentado
        Assert.AreEqual(13f, Mathf.RoundToInt(rb.velocity.y));
    }

    [UnityTest]
    public IEnumerator Move_Right_ShouldIncreaseHorizontalVelocity()
    {
        playerMovement.speed = 5f;

        // Simular la entrada del jugador
        playerMovement.SetHorizontalInput(1);

        // Esperar un cuadro para que se llame a Update y FixedUpdate
        yield return new WaitForFixedUpdate();

        // Verificar que la velocidad horizontal ha aumentado
        Assert.AreEqual(5f, rb.velocity.x);
    }

    [UnityTest]
    public IEnumerator Fall_BelowThreshold_ShouldResetPosition()
    {
        playerMovement.fallThreshold = -10f;
        playerMovement.initialPosition = new Vector3(0, 0, 0);

        // Colocar al jugador por debajo del umbral de caída
        player.transform.position = new Vector3(0, -11f, 0);

        // Esperar un cuadro para que se llame a Update
        yield return null;

        // Verificar que la posición del jugador se ha reseteado
        Assert.AreEqual(playerMovement.initialPosition, player.transform.position);
        Assert.AreEqual(Vector2.zero, rb.velocity);
    }
}
