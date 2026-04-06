using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Pack Maker", story: "Make Pack with [NearbySpecies]", category: "Action", id: "0368e0a2f9270506abcf7d4ce6474cfc")]
public partial class PackMakerAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> NearbySpecies;
    [SerializeReference] public BlackboardVariable<GameObject> self, PackLeader;
    [SerializeReference] public BlackboardVariable<bool> inPack;
    [SerializeReference] public BlackboardVariable<List<GameObject>> PackMembers;

    protected override Status OnStart()
    {
        if (NearbySpecies.Value.TryGetComponent(out BehaviorGraphAgent behaviorGraph))
        {
            behaviorGraph.GetVariable("InPack", out BlackboardVariable<bool> targetInPack);
            if (targetInPack.Value == false && inPack.Value == false)
            {
                behaviorGraph.SetVariableValue("InPack", true);
                inPack.Value = true;
                behaviorGraph.SetVariableValue("PackLeader", self.Value);
                PackLeader.Value = self.Value;
                PackMembers.Value = new List<GameObject> { self.Value, NearbySpecies.Value };
                behaviorGraph.SetVariableValue("PackMembers", PackMembers.Value);
            }
            else if (targetInPack.Value == true && inPack.Value == false)
            {
                behaviorGraph.GetVariable("PackLeader", out BlackboardVariable<GameObject> targetPackLeader);
                behaviorGraph.GetVariable("PackMembers", out BlackboardVariable<List<GameObject>> targetPackMembers);
                targetPackMembers.Value.Add(self.Value);
                PackLeader.Value = targetPackLeader.Value;
                PackMembers.Value = targetPackMembers.Value;
                inPack.Value = true;
            }
            else if (targetInPack.Value == false && inPack.Value == true)
            {
                behaviorGraph.SetVariableValue("InPack", true);
                inPack.Value = true;
                behaviorGraph.SetVariableValue("PackLeader", PackLeader.Value);
                PackLeader.Value = self.Value;
                PackMembers.Value.Add(NearbySpecies.Value);
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

