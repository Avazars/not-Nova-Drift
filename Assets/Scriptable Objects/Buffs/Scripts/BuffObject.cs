using Misc;
using UnityEngine;

namespace Scriptable_Objects.Buffs.Scripts
{
    public enum BuffType
    {
        Decaying,
        Timed,
        Evolving,
        Permanent,
    }
    
    public abstract class BuffObject : ScriptableObject
    {
        protected GameObject buffedObject;
        
        protected bool BuffOver;
        protected bool BuffActive;
        
        protected BuffType type;
        protected CoolDownTimer timer;
        
        protected int buffStacks;
        protected int maxStacks;

        public virtual void BuffStart(){}
        public virtual void BuffEnd(){}
        public virtual void BuffDo(){}
    }
}