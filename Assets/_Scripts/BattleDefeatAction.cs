using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Battle Defeat", story: "Stop battle for [NavTarget]", category: "Action", id: "dfd537e012d2f022a16cf38f8c837cf6")]
public partial class BattleDefeatAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> NavTarget;

    protected override Status OnStart()
    {
        if (NavTarget.Value.TryGetComponent(out BehaviorGraphAgent behaviorGraph))
        {
            behaviorGraph.SetVariableValue("InBattle", false);
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

