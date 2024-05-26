using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [System.Serializable]
    public struct WheelInfo
    {
        public Transform visualwheels;
        public WheelCollider wheelCollider;
    }

    [SerializeField]
    private float _motor, _steer, _brake;

    [SerializeField]
    public WheelInfo _FR, _FL, _BR, _BL;

    private float _vert;
    private float _hort;

    private Vector3 _position;
    private Quaternion _rotation;

    private void FixedUpdate()
    {
        _vert = Input.GetAxis("Vertical");
        _hort = Input.GetAxis("Horizontal");
        _FR.wheelCollider.steerAngle = _hort * _steer;
        _FL.wheelCollider.steerAngle = _hort * _steer;
        _BR.wheelCollider.motorTorque = _vert * _motor;
        _BL.wheelCollider.motorTorque = _vert * _motor;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _FL.wheelCollider.brakeTorque = _brake;
            _FR.wheelCollider.brakeTorque = _brake;
            _BL.wheelCollider.brakeTorque = _brake;
            _BR.wheelCollider.brakeTorque = _brake;
        }
        else
        {
            _FL.wheelCollider.brakeTorque = 0;
            _FR.wheelCollider.brakeTorque = 0;
            _BL.wheelCollider.brakeTorque = 0;
            _BR.wheelCollider.brakeTorque = 0;
        }


        UpdateVisualWheels();
    }

    private void UpdateVisualWheels()
    {
        _FL.wheelCollider.GetWorldPose(out _position, out _rotation);
        _FL.visualwheels.position = _position;
        _FL.visualwheels.rotation = _rotation;

        _FR.wheelCollider.GetWorldPose(out _position, out _rotation);
        _FR.visualwheels.position = _position;
        _FR.visualwheels.rotation = _rotation;

        _BL.wheelCollider.GetWorldPose(out _position, out _rotation);
        _BL.visualwheels.position = _position;
        _BL.visualwheels.rotation = _rotation;

        _BR.wheelCollider.GetWorldPose(out _position, out _rotation);
        _BR.visualwheels.position = _position;
        _BR.visualwheels.rotation = _rotation;
    }
}
