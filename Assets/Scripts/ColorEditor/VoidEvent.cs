using System;
using LevelEditor;
using UnityEngine.Events;

[Serializable] public class VoidEvent : UnityEvent{ }

[Serializable] public class LevelObjectEvent : UnityEvent<StateManager, LevelObject>{ }