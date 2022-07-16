using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Camera cam;
    public LayerMask mask;
    public ItemInfo Slot1;
    public bool _Slot1;
    public ItemInfo Slot2;
    public bool _Slot2;
    public Transform L_hand;
    public Transform R_hand;
    public GameObject CurWeapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            EquipWeapon(Slot1,_Slot1,Slot1._isRHand);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            EquipWeapon(Slot2,_Slot2,Slot2._isRHand);
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
                if (hit.collider.GetComponent<ItemInfo>())
                {
                    AddItem(hit.collider.gameObject.GetComponent<ItemInfo>());
                    Destroy(hit.collider.gameObject);
                }
        }
    }
    void AddItem(ItemInfo item)
    {
        if (!_Slot1)
        {
            Slot1 = item;
            _Slot1 = true;
        }
        else
        {
            Slot2 = item;
            _Slot2 = true;
        }
    }
    void EquipWeapon(ItemInfo Slot,bool bSlot,bool hand)
    {
        Destroy(CurWeapon);
        if (bSlot)
        {
            if (hand)
            {
                GameObject go = Instantiate(Resources.Load<GameObject>(Slot.Prefab), R_hand);
                go.transform.localPosition = Slot.pos;
                go.transform.localRotation = Quaternion.Euler(Slot.rot);
                Destroy(go.GetComponent<ItemInfo>());
                Destroy(go.GetComponent<Rigidbody>());
                Destroy(go.GetComponent<BoxCollider>());
                CurWeapon = go;
            }
            else
            {
                GameObject go = Instantiate(Resources.Load<GameObject>(Slot.Prefab), L_hand);
                go.transform.localPosition = Slot.pos;
                go.transform.localRotation = Quaternion.Euler(Slot.rot);
                Destroy(go.GetComponent<ItemInfo>());
                Destroy(go.GetComponent<Rigidbody>());
                Destroy(go.GetComponent<BoxCollider>());
                CurWeapon = go;
            }
        }
    }
}
