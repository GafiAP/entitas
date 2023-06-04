using Entitas;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;
[Input,Unique]
public class InputComponent : IComponent
{
    public Vector3 value;
}