using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    private bool _dragAndThrow;
    private bool _hasCaughted;

    public float lifeTime;

    void Update()
    {
        _dragAndThrow = this.GetComponent<Lanzar>().isThrow;
        _hasCaughted = this.GetComponent<PokeballManager>().HasCaught;

        if (_dragAndThrow)
        {
            StartCoroutine(Espera());
        }
    }


    IEnumerator Espera()
    {
        yield return new WaitForSeconds(3f);
        if (!_hasCaughted)
        {
            Destroy(gameObject, lifeTime);
        }
    }
}
