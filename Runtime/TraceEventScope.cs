using System;
using UnityEngine;

namespace Kogane.CompleteEventsTracer
{
    public sealed class TraceEventScope : IDisposable
    {
        private readonly string m_name;
        private readonly string m_category;
        private readonly long   m_processId;
        private readonly long   m_threadId;
        private readonly float  m_startTime;

        private float m_duration;

        public TraceEventScope
        (
            string name,
            string category,
            long   processId,
            long   threadId
        )
        {
            m_name      = name;
            m_category  = category;
            m_processId = processId;
            m_threadId  = threadId;
            m_startTime = Time.realtimeSinceStartup;
        }

        public void Dispose()
        {
            m_duration = Time.realtimeSinceStartup - m_startTime;
        }

        internal JsonTraceEvent CreateTraceEvent()
        {
            return new
            (
                name: m_name,
                cat: m_category,
                ph: "X",
                ts: ( long ) ( m_startTime * 1000 ),
                dur: m_duration * 1000,
                tts: 0,
                pid: m_processId,
                tid: m_threadId);
        }
    }
}