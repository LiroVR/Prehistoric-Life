using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Random List Item", story: "Sets [NavTarget] to random point in [Waypoints]", category: "Action", id: "47a78b1eb3f3bc153440aeada28505c7")]
public partial class RandomListItemAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> NavTarget;
    [SerializeReference] public BlackboardVariable<List<GameObject>> Waypoints;

    protected override Status OnStart()
    {
        if (Waypoints.Value.Count > 0)
        {
            NavTarget.Value = Waypoints.Value[UnityEngine.Random.Range(0, Waypoints.Value.Count-1)];
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

