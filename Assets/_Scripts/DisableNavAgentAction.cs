using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Disable Nav Agent", story: "Disables Navigation on [NavTarget]", category: "Action", id: "f2c439efb2478ce6a293eab3f0fc770a")]
public partial class DisableNavAgentAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> NavTarget;

    protected override Status OnStart()
    {
        if (NavTarget.Value.TryGetComponent(out UnityEngine.AI.NavMeshAgent agent) && NavTarget.Value.TryGetComponent(out BehaviorGraphAgent behaviorGraph))
        {
            agent.enabled = false;
            behaviorGraph.SetVariableValue("Health", 0);
            //behaviorGraph.enabled = false;
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

