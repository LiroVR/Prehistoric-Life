using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Pack Battle", story: "Set InBattle for all [PackMembers]", category: "Action", id: "6c3d8f0cfb86c0c4212fe34230ee6ca8")]
public partial class PackBattleAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> PackMembers;

    protected override Status OnStart()
    {
        foreach (var member in PackMembers.Value)
        {
            if (member.TryGetComponent(out BehaviorGraphAgent behaviorGraph))
            {
                behaviorGraph.SetVariableValue("InBattle", true);
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

