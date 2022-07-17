using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Camera Cam;
    public Transform Player;
    private CharacterController Cont;
    public Vector3 offset;
    public float SmoothValue;
    public float MoveSpeed;
    public LayerMask mask;
    public Transform vector;
    public float RollForce;
    public float speedRotation = 2f;
    public float minY = -90f;
    public float maxY = 90f;

    float cameraPitch = 0.0f;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;


    private Vector3 velocity = Vector3.zero;
    private Animator animator;
    void Start()
    {
        Cont = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Controll
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0)
        {
            Cont.Move(Cam.transform.right * horizontal * MoveSpeed * Time.deltaTime);
            animator.SetBool("WalkF", true);
        }
        if (vertical != 0)
        {
            Cont.Move(Cam.transform.forward * vertical * MoveSpeed * Time.deltaTime);
            animator.SetBool("WalkF", true);
        }
        if (horizontal == 0 && vertical == 0)
        {
            animator.SetBool("WalkF", false);
            animator.SetBool("WalkB", false);
        }

        //Player Gravity
        if (!Cont.isGrounded)
            Cont.Move(Physics.gravity * Time.deltaTime);


        //Player Look
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
        Cam.transform.localEulerAngles = Vector3.right * cameraPitch;
        //Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, mask))
        //    transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        // vector.LookAt(Input.mousePosition);
        //Player Roll
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    animator.SetTrigger("Roll");
        //    Cont.Move(transform.forward * Time.deltaTime * RollForce);
        //}


        //Camera Following
        Vector3 NewPos = Player.position + offset;
        Cam.transform.position = Vector3.SmoothDamp(Cam.transform.position, NewPos, ref velocity, SmoothValue);
    }
}