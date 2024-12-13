using UnityEngine;

namespace GWEN
{
    /// <summary>
    /// NPC ���
    /// </summary>
    public class NPCController : MonoBehaviour
    {
        [SerializeField, Header("NPC ���")]
        private DataNPC dataNPC;
        [SerializeField, Header("�ʵe�Ѽ�")]
        private string[] parameters =
        {
            "Ĳ�oLeave","Ĳ�oHit","Ĳ�oDeath","Ĳ�orun","Ĳ�oAttack"
        };


        private Animator ani;

        public DataNPC data => dataNPC;

        private void Awake()
        {
            ani = GetComponent<Animator>();

        }
        public void PlayAinmation(int index)
        {
            ani.SetTrigger(parameters[index]);
        }

    }
}
