using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PetStates
{
    Idle,Moving,Defending,Healing
}

public class Pet : MonoBehaviour
{
    PetStates _petState;

}
