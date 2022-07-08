using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeballManager : MonoBehaviour
{
    public float finalShake;

    public bool HasCaught = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pokemon")
        {
            HasCaught = true;
            StartCoroutine("CatchPokemon", other.gameObject);
        }

    }

    IEnumerator CatchPokemon(GameObject Pokemon)
    {
        transform.Translate(Vector3.up * 0.1f, Space.World);
        this.GetComponent<Rigidbody>().useGravity = false;

        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(Pokemon.gameObject);

        yield return new WaitForSeconds(1);

        this.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1);

        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, 180f, 0f);

        GameObject.FindGameObjectWithTag("MainCamera").transform.LookAt(this.transform);
        GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<Camera>().fieldOfView = 8.2f;

        for (int i = 0; i <= 3; i++)
        {
            if (i == 3)
            
                finalShake = +(finalShake * 3f);
            

            yield return new WaitForSeconds(1f);
            transform.Rotate(Vector3.right * finalShake);
            yield return new WaitForSeconds(0.1f);
            transform.Rotate(-Vector3.right * finalShake);



        }


    }
}
