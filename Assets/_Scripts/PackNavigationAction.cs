using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Pack Navigation", story: "Set [NavTarget] for all [PackMembers]", category: "Action", id: "ebab18443d5f6957893976b91f4968dd")]
public partial class PackNavigationAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> NavTarget;
    [SerializeReference] public BlackboardVariable<List<GameObject>> PackMembers;

    protected override Status OnStart()
    {
        foreach (var member in PackMembers.Value)
        {
            if (member.TryGetComponent(out BehaviorGraphAgent behaviorGraph))
            {
                behaviorGraph.SetVariableValue("NavTarget", NavTarget.Value);
            }
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

