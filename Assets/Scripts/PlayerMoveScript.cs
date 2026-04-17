using UnityEngine;
public class PlayerMoveScript : MonoBehaviour
{
    Rigidbody rb;
    // Vector3 movement = new Vector3(1.0f, 0.0f, 0.0f);

    public float speed = 10f;
    //float jumpForce = 10f;
    public float hosrizontalInput;
    public float verticalInput;

    private AudioSource source;
    public AudioClip walk;
    public AudioClip run;
    public AudioClip jump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        hosrizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

       if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (source.isPlaying == false)
            {
                source.clip = walk;
                source.Play();
            }
        }
       //else
       // {
       //     source.Stop();
       // }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            if (source.isPlaying == false)
            {  
                source.clip = walk;
                source.Play();
            }
        }
        //else
        //{
        //    source.Stop();
        //}


        //if(Input.GetKeyDown(KeyCode.W))
        //{
        //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //}
    }

    void FixedUpdate()
    {
        // If we change to movePosition, make sure to make the player rigidbody to interpolate and collision detection maybe make it continuous
        Vector3 move =  new Vector3(hosrizontalInput, 0, verticalInput)  * speed;
        rb.velocity = move;
     }
}
