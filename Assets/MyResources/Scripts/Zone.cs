using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private GameObject[] _zombies = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var zombie in _zombies)
            {
                zombie.GetComponent<Animator>().SetBool("IsDeath", true);
                zombie.GetComponent<Enemy>().Death();
            }
        }
    }
}
