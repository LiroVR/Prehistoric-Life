using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Randomize Start Values", story: "Sets Starting Parameters", category: "Action", id: "d7b1bd66f8779cea3d73e5a3eb34d24e")]

public partial class RandomizeStartValuesAction : Action
{
    [SerializeReference] public BlackboardVariable<int> health, hunger, thirst, age;

    protected override Status OnStart()
    {
        health.Value = UnityEngine.Random.Range(50, 100);
        hunger.Value = UnityEngine.Random.Range(0, 50);
        thirst.Value = UnityEngine.Random.Range(0, 50);
        age.Value = UnityEngine.Random.Range(1, 10);
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

