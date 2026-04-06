using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Pack Action", story: "Set CurrentAction for [PackMembers]", category: "Action", id: "65bddd52a16b20acba0cab8798dd2c6b")]
public partial class PackAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> PackMembers;
    [SerializeReference] public BlackboardVariable<CurrentAction> currentAction;

    protected override Status OnStart()
    {
        //Changes the CurrentAction enum for all of the pack members
        foreach (GameObject member in PackMembers.Value)
        {
            if (member.TryGetComponent(out BehaviorGraphAgent behaviorGraph))
            {
                behaviorGraph.SetVariableValue("CurrentAction", currentAction.Value);
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

