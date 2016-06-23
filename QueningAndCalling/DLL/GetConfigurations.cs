using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using GJJCallingSys.Models;
using LxbXml;

namespace GJJCallingSys.DLL
{
    class GetConfigurations:Interface.IGetConfiguratons
    {
        private GetConfigurations() { }

        /// <summary>
        /// Get the connection configurations from xml file
        /// </summary>
        /// <param name="fileName">The hole file name,inclode the path and name</param>
        /// <returns></returns>
        public static List<Confg> GetConnectionConfigurationsFromXml(string fileName)
        {
            try
            {
                var connConfgs = new List<Confg>();
                var nodeList = XMLHelper.GetXmlNodeListByXpath(fileName, "//Connections//Appender");
                foreach (XmlNode node in nodeList)
                {
                    //connConfgs.Add(new ConnConfg(name: node.Attributes["name"].Value, cfgType: node.Attributes["Type"].Value));
                    connConfgs.Add(GetConfigurationsFromNode(node));
                }
                return connConfgs;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //public static List<Confg> GetConnectionConfigurationsFromXml(string fileName)
        //{
        //    try
        //    {
        //        var layoutComponents = new List<Confg>();
        //        var nodeList = XMLHelper.GetXmlNodeByXpath(fileName, "//Layout//Appender");
        //        foreach (XmlNode node in nodeList)
        //        {
        //            layoutComponents.Add(GetConfigurationsFromNode(node));
        //        }
        //        return layoutComponents;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private static Confg GetConfigurationsFromNode(XmlNode xNode)
        {
            var CfgNode = xNode.SelectSingleNode("Configuration");

            Dictionary<string, string> Configurations = new Dictionary<string, string>();
            Configurations.Add("ConnectionString", CfgNode.Attributes["ConnectionString"].Value);
            Configurations.Add("Port", CfgNode.Attributes["Port"].Value);

            return new Confg(name: xNode.Attributes["Name"].Value, cfgType: xNode.Attributes["Type"].Value, configurations: Configurations);

        }

    }
}
