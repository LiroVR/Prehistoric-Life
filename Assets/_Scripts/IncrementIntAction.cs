using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Increment INT", story: "Increment [INT] by 1", category: "Action", id: "6ba71fd1228f8cb5fa9758f8e8a0a2b9")]
public partial class IncrementIntAction : Action
{
    [SerializeReference] public BlackboardVariable<int> INT;

    protected override Status OnStart()
    {
        INT.Value += 1;
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

