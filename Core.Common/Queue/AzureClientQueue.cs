using Azure.Messaging.ServiceBus;
using Core.Common.Configuration;
using Core.Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Common.Queue {
    public class AzureClientQueue {
        private static Dictionary<string, SenderQueue> _senders = new Dictionary<string, SenderQueue>();

        public static ServiceBusClient ServiceBusClient => new ServiceBusClient(ConfigurationManager.AppSettings["AzureBusConnection"]);

        public static SenderQueue GetOrCreateQueueSender(string queueName) {
            lock (_senders) {
                if (!_senders.ContainsKey(queueName)) {
                    var sender = ServiceBusClient.CreateSender(queueName);
                    _senders.Add(queueName, new SenderQueue(sender));
                }

                return _senders[queueName];
            }
        }

    }

    public class SenderQueue {
        private ServiceBusSender _sender;
        public SenderQueue(ServiceBusSender sender) {
            _sender = sender;
        }
        public virtual async Task SendMessageAsync(DataMessageQueue message) {
            using (ServiceBusMessageBatch messageBatch = await _sender.CreateMessageBatchAsync()) {
                try {
                    var busMessage = new ServiceBusMessage(JsonConvert.SerializeObject(message));
                    if (!string.IsNullOrWhiteSpace(message.Type))
                        busMessage.ApplicationProperties["MessageType"] = message.Type;
                    if (!messageBatch.TryAddMessage(busMessage)) {
                        throw new Exception($"The message is too large to fit in the batch.");
                    }
                    await _sender.SendMessagesAsync(messageBatch);
                } catch (Exception) {
                    //TODO: log the error
                    throw;
                }
            }
        }

        public virtual async Task SendInBatchsAsync(IEnumerable<DataMessageQueue> messages, int maxBatchSize = 3) {
            if (messages.Count() <= maxBatchSize) {
                using (ServiceBusMessageBatch messageBatch = await _sender.CreateMessageBatchAsync()) {
                    try {
                        foreach (var message in messages) {
                            var busMessage = new ServiceBusMessage(JsonConvert.SerializeObject(message));
                            if (!string.IsNullOrWhiteSpace(message.Type))
                                busMessage.ApplicationProperties["MessageType"] = message.Type;
                            if (!messageBatch.TryAddMessage(busMessage)) {
                                throw new Exception($"The message is too large to fit in the batch.");
                            }
                        }
                        await _sender.SendMessagesAsync(messageBatch);
                    } catch (Exception) {
                        //TODO: log the error
                        throw;
                    }
                }
            }
            else {
                var batches = messages.Partition(maxBatchSize);
                foreach (var batch in batches) {
                    using (ServiceBusMessageBatch messageBatch = await _sender.CreateMessageBatchAsync()) {
                        try {
                            foreach (var message in batch) {
                                var busMessage = new ServiceBusMessage(JsonConvert.SerializeObject(message));
                                if (!string.IsNullOrWhiteSpace(message.Type))
                                    busMessage.ApplicationProperties["MessageType"] = message.Type;
                                if (!messageBatch.TryAddMessage(busMessage)) {
                                    throw new Exception($"The message is too large to fit in the batch.");
                                }
                            }
                            await _sender.SendMessagesAsync(messageBatch);
                        } catch (Exception) {
                            //TODO: log the error
                            throw;
                        }
                    }
                }

            }

        }


    }
}
