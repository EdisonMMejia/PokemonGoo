using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzar : MonoBehaviour
{
    private float distance;
    public float ThorwSpeed;
    public float ArchSpeed;
    public float Speed;


    public bool isThrow = false;
    private bool dragging = false;

    [SerializeField]
    private Camera mainCamera;

    //Cuando demos click se optiene una distancia
    void OnMouseDown()
    {
        distance = Vector3.Distance ( this.transform.position, mainCamera.transform.position);
        dragging = true;
    }


    //cuando se suelta el boton del raton o el dedo
    void OnMouseUp()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().velocity += this.transform.forward * ThorwSpeed;
        this.GetComponent<Rigidbody>().velocity += this.transform.up * ArchSpeed;

        dragging = false;
        isThrow = true;
    }

    void Updatep()
    {
        if (dragging)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint (distance);
            transform.position = Vector3.Lerp(this.transform.position, rayPoint, Speed * Time.deltaTime);
        }
    }


}
