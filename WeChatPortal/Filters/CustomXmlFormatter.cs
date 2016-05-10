using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using WeChatPortal.Utils;

namespace WeChatPortal.Filters
{
    public class CustomXmlFormatter: BufferedMediaTypeFormatter
    {
        public CustomXmlFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
        }
        public override bool CanReadType(Type type)
        {

            return true;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            ////base.WriteToStream(type, value, writeStream, content);
            //var xmlWriterSettings = new XmlWriterSettings {OmitXmlDeclaration = true, Encoding = Encoding.UTF8};
            //using (XmlWriter writer = XmlWriter.Create(writeStream, xmlWriterSettings))
            //{
            //    var namespaces = new XmlSerializerNamespaces();
            //    namespaces.Add(string.Empty, string.Empty);
            //    var serializer = new XmlSerializer(type);
            //    serializer.Serialize(writer, value, namespaces);
            //}
            var encoding = base.SelectCharacterEncoding(content.Headers);
          
          
            var settings = new XmlWriterSettings();
            settings.Encoding = encoding;
            var writer = XmlWriter.Create(writeStream, settings);
            var resource = (LinkedResource)value;
            if (resource is IEnumerable<>)
            {
                writer.WriteStartElement("resource");
                writer.WriteAttributeString("href", resource.HRef);
                foreach (LinkedResource innerResource in (IEnumerable)resource)
                {
                    // Serializes the resource state and links recursively
                    SerializeInnerResource(writer, innerResource);
                }
                writer.WriteEndElement();
            }
            else
            {
                // Serializes a single linked resource
                SerializeInnerResource(writer, resource);
            }
            writer.Flush();
            writer.Close();


            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            var obj = value.ToXml();
            byte[] array = encoding.GetBytes(obj.ToString());

            writeStream = new MemoryStream(array);
        }

        public override object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            //return base.ReadFromStream(type, readStream, content, formatterLogger);
            var serializer = new XmlSerializer(type);
            return serializer.Deserialize(readStream);
        }
    }
}