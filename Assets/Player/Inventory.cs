using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Sprite background;
    public Camera cam;
    public float PickUpDistance;
    public LayerMask mask;
    public Image _iSlot1;
    public Image _iSlot2;
    public ItemInfo Slot1;
    public bool _Slot1;
    public ItemInfo Slot2;
    public bool _Slot2;
    public Transform L_hand;
    public Transform R_hand;
    public GameObject CurWeapon;
    [HideInInspector]
    public ItemInfo CurSlot;
    private int CurSID;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurWeapon)
            if(Input.GetKeyDown(KeyCode.G))
            {
                Destroy(CurWeapon);
                GameObject drop = Instantiate(Resources.Load<GameObject>(CurSlot.Prefab), transform.forward+transform.position, Quaternion.Euler(90,0,0));
                if (CurSID == 1)
                {
                    _Slot1 = false;
                    _iSlot1.color = new Color(255, 255, 255);
                    _iSlot1.transform.parent.GetComponent<Image>().color = new Color(0, 0, 0);
                    _iSlot1.sprite = background;
                }
                if (CurSID == 2)
                {
                    _Slot2 = false;
                    _iSlot2.color = new Color(255, 255, 255);
                    _iSlot2.transform.parent.GetComponent<Image>().color = new Color(0, 0, 0);
                    _iSlot2.sprite = background;
                }
                }
        if (_Slot1)
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                EquipWeapon(Slot1, _Slot1, Slot1._isRHand);
                CurSID = 1;
                GetComponent<CombatSystem>().CurDmg = Slot1.damage;
                _iSlot1.transform.parent.GetComponent<Image>().color = new Color(0, 142, 0);
                _iSlot2.transform.parent.GetComponent<Image>().color = new Color(0, 0, 0);
            }
        if (_Slot2)
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                EquipWeapon(Slot2, _Slot2, Slot2._isRHand);
                CurSID = 2;
                GetComponent<CombatSystem>().CurDmg = Slot2.damage;
                _iSlot2.transform.parent.GetComponent<Image>().color = new Color(0, 142, 0);
                _iSlot1.transform.parent.GetComponent<Image>().color = new Color(0, 0, 0);
            }
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
                if (hit.collider.GetComponent<ItemInfo>())
                    if (!hit.collider.GetComponent<ItemInfo>()._isPickedUp)
                    {
                        float dist = Vector3.Distance(transform.position, hit.collider.transform.position);
                        if(dist <= PickUpDistance)
                            AddItem(hit.collider.GetComponent<ItemInfo>());
                    }
        }
    }
    void AddItem(ItemInfo item)
    {
        if (!_Slot1)
        {
            Slot1 = item;
            _Slot1 = true;
            _iSlot1.sprite = Resources.Load<Sprite>(item.Icon);
            GetComponent<Animator>().SetTrigger("PickUp");
            item.gameObject.GetComponent<ItemInfo>()._isPickedUp = true;
            Destroy(item.gameObject, .45f);
        }
        else
            if(!_Slot2)
            {
                Slot2 = item;
                _Slot2 = true;
                _iSlot2.sprite = Resources.Load<Sprite>(item.Icon);
                GetComponent<Animator>().SetTrigger("PickUp");
                item.gameObject.GetComponent<ItemInfo>()._isPickedUp = true;
                Destroy(item.gameObject, .45f);
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
                CurSlot = Slot;
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
                CurSlot = Slot;
            }
        }
    }
}
