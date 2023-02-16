// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");


TraceSource ts = new TraceSource("Peters Demo");
ts.Switch = new SourceSwitch("Peters Log", "All");

TraceListener listener = new ConsoleTraceListener();
ts.Listeners.Add(listener);

TraceListener filListener = new TextWriterTraceListener(new StreamWriter("TraceDemo.txt"));
ts.Listeners.Add(filListener);

TraceListener xmlListener = new XmlWriterTraceListener(new StreamWriter("TraceDemo.xml"));
xmlListener.Filter = new EventTypeFilter(SourceLevels.Error);
ts.Listeners.Add(xmlListener);










ts.TraceEvent(TraceEventType.Information, 567, "This is information");
ts.TraceEvent(TraceEventType.Warning, 567, "This is warning");
ts.TraceEvent(TraceEventType.Error, 567, "This is error");
ts.TraceEvent(TraceEventType.Critical, 567, "This is critical");

ts.Close();