using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Factories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Factories
{
    public class AttachmentFactory : RestSharpFactory
    {
        public AttachmentFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        #region Protected methods

        public List<Entities.attachment> GetAllAttachments()
        {
            RestRequest request = this.RequestForFilter("attachments/", "full", null, null, null, "attachments");
            return this.Execute<List<Entities.attachment>>(request);
        }
        public Entities.attachment GetAttachmentByInstance(long Id)
        {
            RestRequest request = this.RequestForFilter("attachments/" + Id, null, null, null, null, "attachments");
            Entities.attachment obj = this.Execute<List<Entities.attachment>>(request)?.First() ?? null;
            return obj;
        }
        public Entities.attachment AddAttachmentFile(string filePath)
        {
            RestRequest request = this.RequestForAddAttachment(filePath);
            return this.ExecuteForAttachment<Entities.attachment>(request);
        }

        public Entities.attachment UpdateAttachmentFile(long id, string filePath)
        {
            RestRequest request = this.RequestForUpdateAttachment(filePath, id);
            return this.ExecuteForAttachment<Entities.attachment>(request);
        }
        public void DeleteAttachment(long id)
        {
            RestRequest request = this.RequestForDelete("attachments", id);
            this.Execute<Entities.attachment>(request);
        }

        #endregion
        #region Public Methods
        public Entities.attachment UpdateAttachment(attachment attachment)
        {
            RestRequest request = this.RequestForUpdate("attachments", attachment.id, attachment);
            return this.Execute<Entities.attachment>(request);
        }
        #endregion
    }
}
