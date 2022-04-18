using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Configuration")]
public class GameConfigSO : ScriptableObject
{
    public float _speedDoorDown;
    public float _speedPlateDown;

    public float _speedPlayer;

    public float _targetDownPointDoor;
    public float _targetDownPointPlate;

    public Vector3 _startPlayerPoint;
}
