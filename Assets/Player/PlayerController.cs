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
    public Transform look;
    public float RollForce;
    public float sensetivity;


    private float currentY;
    private Vector3 velocity = Vector3.zero;
    private Animator animator;
    void Start()
    {
        currentY = Cam.transform.rotation.eulerAngles.x;
        Cont = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
       // Cursor.lockState = CursorLockMode.Locked;
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
        //float mX = Input.GetAxis("Mouse X");
        //float mY = Input.GetAxis("Mouse Y");
        //if (mX != 0)
        //    transform.Rotate(transform.up * mX * sensetivity * Time.deltaTime);
        //if (mY != 0)
        //{
        //    currentY = Mathf.Clamp(currentY - mY * sensetivity * Time.deltaTime, -90f, 90f);
        //    Vector3 camRotation = Cam.transform.rotation.eulerAngles;
        //    Cam.transform.rotation = Quaternion.Euler(currentY, camRotation.y, camRotation.z);
        //}
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, mask))
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z+Mathf.Sin(55)));
        //vector.LookAt(Input.mousePosition);
        //Player Roll
        //    if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    animator.SetTrigger("Roll");
        //    Cont.Move(transform.forward * Time.deltaTime * RollForce);
        //}


        //Camera Following
        Vector3 NewPos = Player.position + offset;
        Cam.transform.position = Vector3.SmoothDamp(Cam.transform.position, NewPos, ref velocity, SmoothValue);
    }
}