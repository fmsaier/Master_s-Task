using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace YingMo
{
    [CreateAssetMenu(fileName = "KnowledgeData", menuName = "KnowledgeData", order = 1)]
    public class KnowledgeData : ScriptableObject
    {
        [Multiline(20)]
        public string knowledge;
    }
}
