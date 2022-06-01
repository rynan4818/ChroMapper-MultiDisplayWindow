using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChroMapper_MultiDisplayWindow.Component
{
    public class ActionMapsController : MonoBehaviour
    {
        public static List<Type> queuedToDisable = new List<Type>();
        public static List<Type> queuedToEnable = new List<Type>();

        /*　インプットUIの入力中のショートカットキー無効化用
         *　使用する場合はMultiDisplayControllerのStart()でactionMapsControllerをアクティブにすること
        private static readonly Type[] actionMapsEnabledWhenNodeEditing =
        {
            typeof(CMInput.ICameraActions), typeof(CMInput.IBeatmapObjectsActions),
            typeof(CMInput.ISavingActions), typeof(CMInput.ITimelineActions)
        };

        private static Type[] actionMapsDisabled => typeof(CMInput).GetNestedTypes()
            .Where(x => x.IsInterface && !actionMapsEnabledWhenNodeEditing.Contains(x)).ToArray();

        public static void InputDisable()
        {
            DisableAction(actionMapsDisabled);
        }
        public static void InputEnable()
        {
            EnableAction(actionMapsDisabled);
        }
        */
        public static void DisableAction(Type[] actionMaps)
        {
            foreach (Type actionMap in actionMaps)
            {
                queuedToEnable.Remove(actionMap);
                if (!queuedToDisable.Contains(actionMap))
                    queuedToDisable.Add(actionMap);
            }
        }

        public static void EnableAction(Type[] actionMaps)
        {
            foreach (Type actionMap in actionMaps)
            {
                queuedToDisable.Remove(actionMap);
                if (!queuedToEnable.Contains(actionMap))
                    queuedToEnable.Add(actionMap);
            }
        }
        public static void QueuedActionMaps()
        {
            if (queuedToDisable.Any())
                CMInputCallbackInstaller.DisableActionMaps(typeof(ActionMapsController), queuedToDisable.ToArray());
            queuedToDisable.Clear();
            if (queuedToEnable.Any())
                CMInputCallbackInstaller.ClearDisabledActionMaps(typeof(ActionMapsController), queuedToEnable.ToArray());
            queuedToEnable.Clear();
        }
        private void Update()
        {
            QueuedActionMaps();
        }
    }
}
