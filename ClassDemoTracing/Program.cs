// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Xml;

Console.WriteLine("Hello, World!");


TraceSource ts = new TraceSource("Peters Demo");
ts.Switch = new SourceSwitch("Peters Log", "All");

TraceListener listener = new ConsoleTraceListener();
ts.Listeners.Add(listener);

TraceListener filListener = new TextWriterTraceListener(new StreamWriter("TraceDemo.txt") { AutoFlush=true});
ts.Listeners.Add(filListener);

TraceListener xmlListener = new XmlWriterTraceListener(new StreamWriter("TraceDemo.xml") { AutoFlush = true });
xmlListener.Filter = new EventTypeFilter(SourceLevels.Error);
ts.Listeners.Add(xmlListener);


TraceListener eventLogListener = new EventLogTraceListener("Application");
ts.Listeners.Add(eventLogListener);
Trace.AutoFlush= true;






ts.TraceEvent(TraceEventType.Information, 567, "This is information");
ts.TraceEvent(TraceEventType.Warning, 567, "This is warning");
ts.TraceEvent(TraceEventType.Error, 567, "This is error");
ts.TraceEvent(TraceEventType.Critical, 567, "This is critical");

//ts.Flush();
//ts.Close();




/*
 * Configuration File
 */
XmlDocument xml = new XmlDocument();
xml.Load("Config.file.xml");


Console.WriteLine("name");
XmlNode? nameNode = xml.DocumentElement.SelectSingleNode("Name");
if (nameNode is not null)
{
    String str = nameNode.InnerText;
    Console.WriteLine(str);
}

Console.WriteLine("number");
XmlNode? numberNode = xml.DocumentElement.SelectSingleNode("Number");
if (numberNode is not null)
{
    String str = numberNode.InnerText;
    int number = int.Parse(str);
    Console.WriteLine(number);
}
