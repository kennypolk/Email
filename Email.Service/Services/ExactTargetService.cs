using System;
using System.Collections.Generic;
using System.Linq;
using Email.Service.Interfaces;
using ETServiceClient.ETClient;

namespace Email.Service.Services
{
    public class ExactTargetService : IExactTargetService
    {
        private readonly string username;
        private readonly string password;

        public ExactTargetService(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void CheckStatus()
        {

        }

        public ETServiceClient.ETClient.Email GetEmail(int id)
        {
            return new ETServiceClient.ETClient.Email();
        }

        public void SendEmail(int templateId, List<Dictionary<string, string>> mergeCodes, string emailExtensionField, string emailSubject)
        {
            var providerObjectId = Guid.NewGuid().ToString();

            var mergeFields = mergeCodes[0].Select(x => x.Key).ToList();
            var dataExtensionId = CreateDataExtension(templateId.ToString(), providerObjectId, mergeFields, emailExtensionField);

            CreateDataExtensionObjects(mergeCodes, dataExtensionId);

            var sendDefinition = CreateSendDefinition(templateId, providerObjectId, emailSubject);

            PerformSendDefinition(sendDefinition);
        }

        private string CreateDataExtension(string templateId, string providerObjectId, List<string> mergeFields, string emailExtensionField)
        {

            var extenstionFields = mergeFields.Select(mergeField => new DataExtensionField
            {
                Name = mergeField,
                CustomerKey = mergeField,
                FieldType = DataExtensionFieldType.Text
            }).ToList();

            extenstionFields.Add(new DataExtensionField
            {
                Name = emailExtensionField,
                CustomerKey = emailExtensionField,
                FieldType = DataExtensionFieldType.EmailAddress,
                FieldTypeSpecified = true
            });

            var dataExtension = new DataExtension
            {
                Name = providerObjectId,
                CustomerKey = providerObjectId,
                DataRetentionPeriod = DateTimeUnitOfMeasure.Days,
                DataRetentionPeriodLength = 10,
                DataRetentionPeriodLengthSpecified = true,
                DataRetentionPeriodSpecified = true,
                DeleteAtEndOfRetentionPeriod = true,
                DeleteAtEndOfRetentionPeriodSpecified = true,
                Fields = extenstionFields.ToArray(),
                SendableDataExtensionField = new DataExtensionField { Name = emailExtensionField },
                SendableSubscriberField = new ETServiceClient.ETClient.Attribute { Name = "Email Address" },
                IsSendable = true,
                IsSendableSpecified = true
            };

            using (var client = new SoapClient())
            {
                client.ClientCredentials.UserName.UserName = username;
                client.ClientCredentials.UserName.Password = password;

                string dataExtensionObjectId = null;
                for (var i = 1; i <= 10; i++)
                {
                    try
                    {
                        string status;
                        string requestId;
                        var response = client.Create(new CreateOptions(), new APIObject[] { dataExtension }, out requestId, out status)[0];
                        if (status.Equals("error", StringComparison.CurrentCultureIgnoreCase))
                        {
                            //Log.LogInfoWithMethod("CreateDataExtension", string.Format("Error creating data extension - Attempt {0}: {1} - {2}", i, response.ErrorCode, response.StatusMessage));
                        }
                        else
                        {
                            dataExtensionObjectId = response.NewObjectID;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Log.LogErrorWithMethod("CreateDataExtension", string.Format("Error CreateDataExtension for Account {0}: {1}", AccountId, ex.InnerException + ex.Message), Guid.NewGuid());
                    }
                }

                if (!string.IsNullOrEmpty(dataExtensionObjectId))
                {
                    return dataExtensionObjectId;
                }

                throw new Exception("CreateDataExtension: Error max attempts reached");
            }
        }

        private void CreateDataExtensionObjects(List<Dictionary<string, string>> mergeFields, string dataExtensionId)
        {
            var dataObjects = mergeFields.Select(mergeField => new DataExtensionObject
            {
                ObjectID = dataExtensionId,
                Properties = mergeField.Select(x => new APIProperty {Name = x.Key, Value = x.Value}).ToArray()
            }).Cast<APIObject>();

            var i = 0;
            //foreach (var group in dataObjects.GroupBy(x => i++ / 250))
            foreach (var group in dataObjects.GroupBy(x => i++ / 25))
            {
                using (var client = new SoapClient())
                {
                    client.ClientCredentials.UserName.UserName = username;
                    client.ClientCredentials.UserName.Password = password;

                    string requestId, status;
                    var response = client.Create(new CreateOptions(), group.ToArray(), out requestId, out status)[0];

                    if (status.ToLower() == "error")
                    {
                        //Log.LogInfoWithMethod("CreateDataExtensionObjects", string.Format("Error creating data extension objects - Attempt {0}: {1} - {2}", i, response.ErrorCode, response.StatusMessage));
                    }
                }
            }
        }

        private EmailSendDefinition CreateSendDefinition(int templateId, string providerObjectId, string subject)
        {
            //TODO Figure out best way to pass this in
            var sendClassificationId = "";

            var sendDefinitionList = new SendDefinitionList
            {
                SendDefinitionListType = SendDefinitionListTypeEnum.SourceList,
                SendDefinitionListTypeSpecified = true,
                CustomerKey = providerObjectId,
                DataSourceTypeID = DataSourceTypeEnum.CustomObject,
                DataSourceTypeIDSpecified = true
            };

            var sendDefinition = new EmailSendDefinition
            {
                Name = providerObjectId,
                CustomerKey = providerObjectId,
                Email = new ETServiceClient.ETClient.Email { ID = templateId, IDSpecified = true, Subject = subject },
                SendClassification = new SendClassification { ObjectID = sendClassificationId },
                SendDefinitionList = new[] { sendDefinitionList },
                IsSendLogging = true,
                IsSendLoggingSpecified = true
            };

            using (var client = new SoapClient())
            {
                client.ClientCredentials.UserName.UserName = username;
                client.ClientCredentials.UserName.Password = password;

                string requestId, status;
                var createResponse = client.Create(new CreateOptions(), new APIObject[] { sendDefinition }, out requestId, out status);
                if (status.ToLower() == "error")
                {
                    //Log.LogInfoWithMethod("PerformSendDefinition", string.Format("Error creating send definition: {0} - {1}", createResponse[0].ErrorCode, createResponse[0].StatusMessage));
                    //if (i == 10)
                    //{
                    //    throw new Exception("PerformSendDefinition: Max attempts reached - Creating send definition");
                    //}
                }
            }

            return sendDefinition;
        }

        private void PerformSendDefinition(EmailSendDefinition sendDefinition)
        {
            using (var client = new SoapClient())
            {
                client.ClientCredentials.UserName.UserName = username;
                client.ClientCredentials.UserName.Password = password;

                string requestId, status, statusMessage;
                var response = client.Perform(new PerformOptions(), "start", new InteractionBaseObject[] { sendDefinition }, out status, out statusMessage, out requestId)[0];
                //if (status.ToLower() == "error")
                //{
                //    Log.LogInfoWithMethod("PerformSendDefinition", string.Format("Error performing send definition - Attempt {0}: {1} - {2}", i, response.ErrorCode, response.StatusMessage));
                //    if (i == 10)
                //    {
                //        throw new Exception("PerformSendDefinition: Max attempts reached - Performing Send definition");
                //    }
                //}
            }
        }
    }
}
