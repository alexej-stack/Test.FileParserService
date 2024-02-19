using System.Xml.Serialization;

namespace Test.Common.Model;

public class RapidControlStatus
{
	[XmlElement("ModuleState")]
	public ModuleState ModuleState { get; set; }

	[XmlElement("IsBusy")]
	public bool IsBusy { get; set; }

	[XmlElement("IsReady")]
	public bool IsReady { get; set; }

	[XmlElement("IsError")]
	public bool IsError { get; set; }

	[XmlElement("KeyLock")]
	public bool KeyLock { get; set; }

	[XmlElement("UseTemperatureControl")]
	public bool UseTemperatureControl { get; set; }

	[XmlElement("OvenOn")]
	public bool OvenOn { get; set; }

	[XmlElement("Temperature_Actual")]
	public double TemperatureActual { get; set; }

	[XmlElement("Temperature_Room")]
	public double TemperatureRoom { get; set; }

	[XmlElement("MaximumTemperatureLimit")]
	public int MaximumTemperatureLimit { get; set; }

	[XmlElement("Valve_Position")]
	public int ValvePosition { get; set; }

	[XmlElement("Valve_Rotations")]
	public int ValveRotations { get; set; }

	[XmlElement("Buzzer")]
	public bool Buzzer { get; set; }

	public static RapidControlStatus LoadFromXmlString(string xmlString)
	{
		var serializer = new XmlSerializer(typeof(RapidControlStatus));

		using (var reader = new StringReader(xmlString))
		{
			return (RapidControlStatus)serializer.Deserialize(reader);
		}
	}
}