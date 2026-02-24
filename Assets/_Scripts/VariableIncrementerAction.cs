using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Variable Incrementer", story: "Increments [Hunger] and [Thirst] over time", category: "Action", id: "0a3b76e2752ea000ecb15e6ba1a36da2")]
public partial class VariableIncrementerAction : Action
{
    [SerializeReference] public BlackboardVariable<int> Hunger;
    [SerializeReference] public BlackboardVariable<int> Thirst;
    protected override Status OnStart()
    {
        Hunger.Value += 1;
        Thirst.Value += 1;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

