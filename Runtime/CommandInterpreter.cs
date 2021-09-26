using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BrightDebugger
{
    public sealed class CommandInterpreter : MonoBehaviour
    {
        private readonly List<BaseCommand> _commands = new List<BaseCommand>();

        private void Awake()
        {
            _commands.Add(new CreateCubeCommand());
        }

        public bool Interpret(string inputString)
        {
            var command = _commands.FirstOrDefault(commandEntry => commandEntry.Id.Equals(inputString.ToLower()));
            if (command != null)
            {
                command.Execute();
                return true;
            }
            return false;
        }
    }
}