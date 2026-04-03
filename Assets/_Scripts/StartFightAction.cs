using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Start Fight", story: "Set target to [Self] on [NavTarget]", category: "Action", id: "3568a8fd9e3f3c162f384accbe3b848d")]
public partial class StartFightAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> NavTarget;

    protected override Status OnStart()
    {
        if (NavTarget.Value.TryGetComponent(out BehaviorGraphAgent behaviorGraph))
        {
            behaviorGraph.SetVariableValue("NavTarget", Self.Value);
            behaviorGraph.SetVariableValue("InBattle", true);
        }
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

