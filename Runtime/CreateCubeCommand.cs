using UnityEngine;

namespace BrightDebugger
{
    public sealed class CreateCubeCommand : BaseCommand
    {
        public CreateCubeCommand() : base("create cube", "Creates a game object", "create cube")
        {
        }

        public override void Execute()
        {
            GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
    }
}