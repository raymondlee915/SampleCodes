using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLTestConsole
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //XmlReaderTest();
            CreateXMLForDirectory();


            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static void XmlReaderTest()
        {
            XmlDocument doc = GetXml();

            // Anaylize the XML document, and give the quick start guide node.
            // find the quick start guide Node first.
            var targetPart = doc.SelectSingleNode("descendant::DocumentList[DocumentTile/DocumentDetails/DocumentTitle[contains(.,'Quick Start')]]");
            var allGuides = targetPart.SelectNodes(".//DocumentLocation");
            List<string> returnValues = new List<string>();
            foreach (var item in allGuides)
            {
                var node = item as XmlNode;
                returnValues.Add(node.InnerText);
            }

            var locale = System.Globalization.CultureInfo.CurrentUICulture.Name.ToLower().Split('-');
            string language = locale[0];
            string region = locale[1];

            var sameLanguageOnes = returnValues.Where(p => p.Contains("_" + language + "-"));
            if (sameLanguageOnes.Count() == 0)
            {
                Console.WriteLine(returnValues.First(p => p.Contains("en-us")));
            }

            var sameRegion = sameLanguageOnes.First(p => p.Contains(region));
            if (sameRegion.Count() == 0)
            {
                Console.WriteLine(sameLanguageOnes.First());
            }

            Console.WriteLine(sameRegion);
        }

        public static XmlDocument GetXml()
        {
            var address = "https://sandbox.api.dell.com/support/manuals/documents.xml?st=B8017Z1&apikey=fb679582e20c801603ff704782e641fc";

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStreamAsync(address);
                XmlDocument doc = new XmlDocument();
                doc.Load(response.Result);

                return doc;
            }
        }

        public static void CreateXMLForDirectory()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Categories_template.xml");

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("lc", "http://www.dell.com/lc");

            var categoriesNode = doc.SelectSingleNode("descendant::lc:Categories", nsmgr);

            using (var directoryDialog = new FolderBrowserDialog())
            {
                DialogResult result = directoryDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var path = directoryDialog.SelectedPath;
                    var directory = Directory.CreateDirectory(path);
                    var subFolders = directory.GetDirectories();

                    var categoryIndex = 0;
                    foreach (var folder in subFolders)
                    {
                        if (folder.Name.Equals("images"))
                        {
                            continue;
                        }

                        var categoryName = folder.Name;

                        var iconFile = folder.GetFiles("*.png").First();

                        var iconPath = string.Format("article\\{0}\\{1}", categoryName, iconFile.Name);

                        var categoryNode = doc.CreateNode(XmlNodeType.Element, "Category", "http://www.dell.com/lc");
                        AddAttributes(doc, categoryNode, categoryName, iconPath, (categoryIndex++).ToString());

                        var filesInfo = folder.GetFiles("*.htm*");
                        var index = 0;
                        foreach (var fileInfo in filesInfo)
                        {
                            var filename = fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.'));
                            var filePath = string.Format("article\\{0}\\{1}", categoryName, fileInfo.Name);
                            var indexStr = (index++).ToString();

                            var articleNode = doc.CreateNode(XmlNodeType.Element, "Article", "http://www.dell.com/lc");
                            AddAttributes(doc, articleNode, filename, filePath, indexStr);

                            categoryNode.AppendChild(articleNode);
                        }

                        categoriesNode.AppendChild(categoryNode);
                    }


                }
            }


            using (var fileSaveDialog = new SaveFileDialog())
            {
                var result = fileSaveDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    doc.Save(fileSaveDialog.FileName);
                }
            }

        }


        private static void AddAttributes(XmlDocument doc, XmlNode node, string title, string path, string index)
        {
            var titleAttr = doc.CreateNode(XmlNodeType.Attribute, "Title", "");
            titleAttr.Value = title;


            var pathAttr = doc.CreateNode(XmlNodeType.Attribute, "Path", "");
            pathAttr.Value = path;

            var indexAttr = doc.CreateNode(XmlNodeType.Attribute, "Index", "");
            indexAttr.Value = index;


            node.Attributes.SetNamedItem(titleAttr);
            node.Attributes.SetNamedItem(pathAttr);
            node.Attributes.SetNamedItem(indexAttr);
        }
    }
}
