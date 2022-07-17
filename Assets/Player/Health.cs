using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public int _health;
    public Slider _hpBar;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Health"))
        _health = (int)(_health * PlayerPrefs.GetFloat("Health"));
    }

    // Update is called once per frame
    void Update()
    {
        _hpBar.value = _health;
        if(_health <= 0)
        {
            _health = 0;
            if (gameObject.name == "Player")
            {
                GetComponent<Animator>().SetBool("Dead", true);
                GetComponent<PlayerController>().enabled = false;
                GetComponent<Inventory>().enabled = false;
                GetComponent<CombatSystem>().enabled = false;
            }
            else
            {
                GetComponent<Slime_AI>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
            }
        }
    }
    public void DamageMe(int dmgAmount)
    {
        _health -= dmgAmount;
    }
}
