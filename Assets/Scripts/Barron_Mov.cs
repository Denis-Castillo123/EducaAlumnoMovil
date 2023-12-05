using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barron_Mov : MonoBehaviour
{
    public GameObject AtaqueE;
    public float Speed;
    public float JumpForce;
    public float JumMax;
    public LayerMask CapaSuelo;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private BoxCollider2D boxCollider;
    private float Horizontal;
    private bool Grounded;
    private float JumpRest;
    public float damageAmount = 10f;

    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private BarraVida barraVida;
    


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Animator = GetComponent<Animator>();
        JumpRest = JumMax;
        vida = maximoVida;
        barraVida.InicializarBarraVida(vida);
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento del personaje
        Horizontal = Input.GetAxisRaw("Horizontal");

        //Establece la dirección en la cual el personaje estara avanzando
        if (Horizontal < 0.0f) transform.localScale = new Vector2 (-10.0f, 10.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector2(10.0f, 10.0f);

        //Llamada de las animaciones de caminar y Suelo
        Animator.SetBool("Caminando", Horizontal != 0.0f);
        //Determina base en el escenario
        Animator.SetBool("EnSuelo",Suelo());
        
        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);

        Jump();

        // if(Input.GetKey(KeyCode.Space))
        // {
        //     Shoot();
        // }
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        barraVida.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            Animator.SetBool("EnSuelo",Suelo());
            //Destroy(gameObject);
        }
    }

    bool Suelo(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x,boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, CapaSuelo);
        return raycastHit.collider != null;
    }

    //Metodo para saltar el personaje
    private void Jump()
    {
        //Determina el limite de saltos del personaje
        if(Suelo()){

            JumpRest = JumMax;
        }

        if (Input.GetKeyDown(KeyCode.W) && JumpRest > 0)
        {
            JumpRest--;
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x,0f);
            Debug.Log("Jumping!");
            Rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    //Metodo para establecer la velocidad y el posicion limite del personaje
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
        Rigidbody2D.position = new Vector2(Mathf.Clamp(Rigidbody2D.position.x, -8.28f, 43.96f),
            Rigidbody2D.position.y);
    }

    // private void Shoot()
    // {
    //     Vector2 direction;
    //     if(transform.localScale.x == 1.0f) direction = Vector2.right;
    //     else direction = Vector2.left;

    //     GameObject ataque = Instantiate(BulletPrefab,transform.position + direction * 0.1f ,Quaternion.identity);
    //     ataque.GetComponent<power>().SetDirection(direction);
    // }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Controlador Chelines"))
        {
            TomarDaño(damageAmount);
            barraVida.CambiarVidaActual(vida);
            Debug.Log("Vida actualizada: " + vida);
        }
    }

}