using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Deal Damage", story: "Deal [Damage] to [NavTarget]", category: "Action", id: "14ee0d465aeaa1f19da42be292e91303")]
public partial class DealDamageAction : Action
{
    [SerializeReference] public BlackboardVariable<int> Damage;
    [SerializeReference] public BlackboardVariable<GameObject> NavTarget;

    protected override Status OnStart()
    {
        if (NavTarget.Value.TryGetComponent(out BehaviorGraphAgent behaviorGraph))
        {
            behaviorGraph.GetVariable("Health", out BlackboardVariable<int> targetHealth);
            behaviorGraph.SetVariableValue("Health", targetHealth - Damage.Value);
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

