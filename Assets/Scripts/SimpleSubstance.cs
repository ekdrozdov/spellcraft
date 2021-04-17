//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SimpleSubstance : MonoBehaviour, Substance
//{
//    private float _density;
//    public float Density
//    {
//        get { return _density; }
//        set
//        {
//            _density = value;
//            print($"Density = {Density}");
//            UpdateMass();
//        }
//    }
//    private float _mass;
//    public float Mass
//    {
//        get { return _mass; }
//        private set
//        {
//            _mass = value;
//            _body.mass = Mass;
//        }
//    }
//    private Vector3 _size;
//    public Vector3 Size
//    {
//        get { return _size; }
//        set
//        {
//            _size = value;
//            print($"Size = {Size}");
//            UpdateMass();
//        }
//    }
//    private Rigidbody _body;
//    private Transform _transform;

//    // Start is called before the first frame update
//    void Start()
//    {
//        _body = GetComponent<Rigidbody>();
//        _transform = GetComponent<Transform>();
//        Density = 1;
//        Size = GetComponent<Transform>().localScale;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (_transform.localScale != Size)
//        {
//            Size = _transform.localScale;
//        }
//        if (Input.GetKeyDown(KeyCode.RightBracket))
//        {
//            Density++;
//        }
//        if (Input.GetKeyDown(KeyCode.LeftBracket))
//        {
//            Density--;
//        }
//    }

//    private void UpdateMass()
//    {
//        Mass = Density * Size.x * Size.y * Size.z;
//        print($"Mass = {Mass}");
//    }
//}
