using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GWEN
{
    /// <summary>
    ///  NPC ���
    /// </summary>
    [CreateAssetMenu(menuName = "GWEN/NPC")]
    public class DataNPC : ScriptableObject
    {
        [Header("NPC AI �n���R���y�l")]
        public string[] sentences;
    }
}
