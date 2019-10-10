using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public Transform destination;
    Rigidbody _rb;
    BoxCollider _collider;
    Camera _camera;

    float _force = 0;
    bool _isTaken = false;

    [Range(0, 100)]
    public float forceIntensity = 10;

    [Header("Materials")]
    public Material outline;
    public Material standart;

    public bool selected;

    public bool _thrown;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();

        standart = GetComponent<Renderer>().material;

        //System D method, can be improved
        _camera = FindObjectOfType<Camera>();
        if (_camera == null) Debug.LogError("NO CAMERA FOUND");
    }

    void SetModeTake()
    {
        _collider.enabled = false;
        _rb.useGravity = false;
        _rb.isKinematic = false;
        this.transform.position = destination.position;
        this.transform.parent = destination;

        _thrown = false;
        _isTaken = true;
    }

    private void SetModeRelease()
    {
        this.transform.parent = null;
        _collider.enabled = true;
        _rb.useGravity = true;
        _rb.isKinematic = false;

        Vector3 lCameraDirection = _camera.transform.forward;

        _rb.AddForce(lCameraDirection * _force, ForceMode.Acceleration);

        _isTaken = false;
        ResetForce();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_thrown && !collision.gameObject.tag.Equals("Room"))
        {
            _rb.useGravity = false;
            _rb.isKinematic = true;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) SetModeTake();
        selected = true;
    }

    private void OnMouseExit()
    {
        selected = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) SetModeRelease();
        if (Input.GetMouseButton(1)) AddForce();
        if (selected)
        {
            GetComponent<Renderer>().material = outline;
            GetComponent<Renderer>().material.mainTexture = standart.mainTexture;
        } else
        {
            GetComponent<Renderer>().material = standart;
        }
    }

    void AddForce()
    {
        if (!_isTaken) return;

        _thrown = true;

        _force += forceIntensity;
        //print(_force);
    }

    void ResetForce()
    {
        _force = 0;
    }
}
