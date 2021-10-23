using UnityEngine;

namespace BrightDebugger
{
    [RequireComponent(typeof(CommandInterpreter))]
    public sealed class DebugConsole : MonoBehaviour
    {
        [SerializeField] private CommandInterpreter _commandInterpreter;

        private bool _visible;
        private string _inputString;
        private static float LINE_HEIGHT = 20f;
        private string _lastString;

        private void Reset()
        {
            _commandInterpreter = GetComponent<CommandInterpreter>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _visible = !_visible;
            }
        }

        private void OnGUI()
        {
            if (!_visible)
            {
                return;
            }

            if (Event.current != null && Event.current.type == EventType.KeyDown)
            {
                if (Event.current.keyCode == KeyCode.Escape)
                {
                    _visible = false;
                    return;
                }

                if (Event.current.keyCode == KeyCode.Return)
                {
                    if(_commandInterpreter.Interpret(_inputString))
                    {
                        _lastString = _inputString;
                    }
                    else
                    {
                        _lastString = $"[{_inputString}] not a valid command";
                    }
                    _inputString = string.Empty;
                }
            }

            var y = 0f;
            GUI.Box(new Rect(0f, y, Screen.width, LINE_HEIGHT * 3), "");
            GUI.backgroundColor = new Color(0, 0, 0, 0);

            GUI.Label(new Rect(10, y + 5, Screen.width - 20f, LINE_HEIGHT), _lastString);
            GUI.SetNextControlName("input");
            _inputString = GUI.TextField(new Rect(10, y + LINE_HEIGHT + 5, Screen.width - 20f, LINE_HEIGHT), _inputString);
            GUI.FocusControl("input");
        
        }
    }
}