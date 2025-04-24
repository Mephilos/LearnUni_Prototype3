using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isOnGround;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crushSound;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb    = GetComponent<Rigidbody>();
        playerAnim  = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound,1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if(!gameOver)
            {
                dirtParticle.Play();
            }
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crushSound,1.0f);
        }
    }
}
