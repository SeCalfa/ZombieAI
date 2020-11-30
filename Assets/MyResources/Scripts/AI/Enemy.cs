using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] internal GameObject[] _wayPoints = null;
    [SerializeField] internal GameObject _player = null;
    [SerializeField] internal GameObject _mark = null;

    private bool isAlive = true;

    private void Awake()
    {
        _mark.SetActive(false);
    }

    internal IEnumerator ExclamationMark()
    {
        _mark.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        _mark.SetActive(false);
    }

    internal void Death()
    {
        isAlive = false;
    }
}
