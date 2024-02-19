using System.Xml.Serialization;

namespace Test.Common.Model;
[XmlRoot("InstrumentStatus")]
public class InstrumentStatus
{
	[XmlElement("PackageID")]
	public string PackageID { get; set; }

	[XmlElement("DeviceStatus")]
	public List<DeviceStatus> DeviceStatusList { get; set; }
}