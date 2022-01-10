using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Kogane.CompleteEventsTracer
{
    // https://docs.google.com/document/d/1CvAClvFfyA5R-PhYUmn5OOQtYMH4h6I0nSsKchNAySU/preview
    [Serializable]
    [SuppressMessage( "ReSharper", "InconsistentNaming" )]
    [SuppressMessage( "ReSharper", "NotAccessedField.Local" )]
    internal sealed class JsonCompleteEvents
    {
        [SerializeField] private JsonTraceEvent[] traceEvents;

        public JsonCompleteEvents( JsonTraceEvent[] traceEvents )
        {
            this.traceEvents = traceEvents;
        }
    }
}