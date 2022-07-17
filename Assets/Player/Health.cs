using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public int _health;
    public Slider _hpBar;
    public Animator anim;
    private bool iml;
    // Start is called before the first frame update
    void Start()
    {
        iml = false;
        _hpBar.maxValue = _health;
        if(PlayerPrefs.HasKey("Health"))
        _health = (int)(_health * PlayerPrefs.GetFloat("Health"));
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _hpBar.value = _health;
        if(_health <= 0)
        {
            _health = 0;
            ImDead();
            Destroy(gameObject, 10f);
        }
    }
    public void DamageMe(int dmgAmount)
    {
        if (!iml)
        {
            _health -= dmgAmount;
            anim.SetTrigger("Hit");
            iml = true;
            StartCoroutine(Immortal());
        }
    }
    public IEnumerator Immortal()
    {
        yield return new WaitForSeconds(0.5f);
        iml = false;
    }
    public void ImDead()
    {
        if (gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetBool("Dead", true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<Inventory>().enabled = false;
            GetComponent<CombatSystem>().enabled = false;
        }
        else
        {
            anim.SetBool("Dead", true);
            GetComponent<Slime_AI>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}
