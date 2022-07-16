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
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        Cont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Controll
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0)
            Cont.Move(Cam.transform.right * horizontal * MoveSpeed * Time.deltaTime);
        if(vertical != 0)
            Cont.Move(Cam.transform.forward * vertical * MoveSpeed * Time.deltaTime);

        //Player Gravity
        if (!Cont.isGrounded)
            Cont.Move(Physics.gravity * Time.deltaTime);

        //Player Look
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));

        //Camera Following
        Vector3 NewPos = Player.position + offset;
        Cam.transform.position = Vector3.SmoothDamp(Cam.transform.position, NewPos, ref velocity, SmoothValue);
    }
}