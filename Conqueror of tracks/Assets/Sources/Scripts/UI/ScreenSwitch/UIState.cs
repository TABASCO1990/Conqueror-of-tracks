using System;
using UnityEngine;

namespace UI.ScreenSwitch
{
    public class UIState : MonoBehaviour
    {
        public static event Action<State, State> StateChanged;

        public static State CurrentState { get; private set; }

        public static void ChangeState(State state)
        {
            StateChanged?.Invoke(CurrentState, state);
            CurrentState = state;
        }
    }
}
